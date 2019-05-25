using ApplicationCore.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public interface ISpecificationEvaluator
    {
        IEnumerable<T> EvaluateSpecification<T>(IQueryable<T> query, ISpecification<T> specification) where T : class;
    }

    /// <summary>
    /// Generic class for applaying specification to given queries
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SpecificationEvaluator : ISpecificationEvaluator
    {
        /// <summary>
        /// Apply given specification to given query
        /// </summary>
        /// <param name="query">Base query</param>
        /// <param name="specification">Specification to apply</param>
        /// <returns>New query containing specification</returns>
        public IEnumerable<T> EvaluateSpecification<T>(IQueryable<T> query, ISpecification<T> specification) where T:class
        {
            var ret = query;
            if(specification.Criteria !=null)
            {
                ret = ret.Where(specification.Criteria);
            }

            if (specification.Take != 0)
                ret = ret.Take(specification.Take);

            if (specification.OrderBy != null)
                ret = ret.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                ret = ret.OrderBy(specification.OrderByDescending);

            return ret.ToList();
        }
        
    }
}
