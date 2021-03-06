﻿using ApplicationCore.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    /// <summary>
    /// Base class for every repository. Implements shared functionality such as adding, removing, finding by id etc.
    /// </summary>
    /// <typeparam name="EntityType">Type of entity</typeparam>
    public abstract class BaseRepository<EntityType,IdType> : IRepository<EntityType,IdType> where EntityType : class
    {
        protected ApplicationContext context;
        private ISpecificationEvaluator specificationEvaluator;
        
        public BaseRepository(
            ApplicationContext context,
            ISpecificationEvaluator specificationEvaluator)
        {
            this.context = context;
            this.specificationEvaluator = specificationEvaluator;
        }

        public void Add(EntityType toAdd)
        {
            context.Set<EntityType>().Add(toAdd);
            context.SaveChanges();
        }

        public IEnumerable<EntityType> GetAll()
        {
            return context.Set<EntityType>().ToList();
        }

        public virtual EntityType GetById(IdType id)
        {
            return context.Set<EntityType>().Find(id);
        }

        public IEnumerable<EntityType> GetList(ISpecification<EntityType> specification)
        {
            return specificationEvaluator.EvaluateSpecification(
                context.Set<EntityType>(),
                specification);
        }

        public void Remove(EntityType toRemove)
        {
            context.Set<EntityType>().Remove(toRemove);
            context.SaveChanges();
        }

        public void Update(EntityType entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
