using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Web.Http;

namespace GoalTracerAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private ITestRepository repo;

        public ValuesController(ITestRepository repo)
        {
            this.repo = repo;
        }

        // GET api/values
        public IEnumerable<Test> Get()
        {
            return repo.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
