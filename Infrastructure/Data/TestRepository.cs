using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public interface ITestRepository: IRepository<Test,int>
    {

    }
    class TestRepository : BaseRepository<Test, int>, ITestRepository
    {
        public TestRepository(ApplicationContext context, ISpecificationEvaluator specificationEvaluator) : base(context, specificationEvaluator)
        {

        }
    }
}
