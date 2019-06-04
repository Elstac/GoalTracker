using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public interface IMainGoalRepository:IRepository<MainGoal,int>
    {
        IEnumerable<MainGoal> GetAllGoalsWithDependencies();
    }
    class MainGoalRepository : BaseRepository<MainGoal, int>, IMainGoalRepository
    {
        public MainGoalRepository(ApplicationContext context, ISpecificationEvaluator specificationEvaluator) : base(context, specificationEvaluator)
        {

        }

        public IEnumerable<MainGoal> GetAllGoalsWithDependencies()
        {
            return context.Set<MainGoal>().Include(mg => mg.Steps).Include(mg => mg.Targets);
        }
    }
}
