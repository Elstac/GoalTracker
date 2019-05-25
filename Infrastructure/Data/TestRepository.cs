using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public interface ITaskRepository: IRepository<Task,int>
    {

    }
    class TestRepository : BaseRepository<Task, int>, ITaskRepository
    {
        public TestRepository(ApplicationContext context, ISpecificationEvaluator specificationEvaluator) : base(context, specificationEvaluator)
        {

        }
    }
}
