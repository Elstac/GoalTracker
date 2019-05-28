using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public interface ITaskRepository: IRepository<Task,int>
    {

    }
    class TaskRepository : BaseRepository<Task, int>, ITaskRepository
    {
        public TaskRepository(ApplicationContext context, ISpecificationEvaluator specificationEvaluator) : base(context, specificationEvaluator)
        {

        }
    }
}
