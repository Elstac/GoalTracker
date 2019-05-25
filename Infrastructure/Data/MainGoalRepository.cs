using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public interface IMainGoalRepository:IRepository<MainGoal,int>
    {

    }
    class MainGoalRepository : BaseRepository<MainGoal, int>, IMainGoalRepository
    {
        public MainGoalRepository(ApplicationContext context, ISpecificationEvaluator specificationEvaluator) : base(context, specificationEvaluator)
        {
        }
    }
}
