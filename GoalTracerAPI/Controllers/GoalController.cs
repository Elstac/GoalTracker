﻿using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GoalTracerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GoalController : ApiController
    {
        private IMainGoalRepository mainGoalRepository;

        public GoalController(IMainGoalRepository mainGoalRepository)
        {
            this.mainGoalRepository = mainGoalRepository;
        }

        // GET api/<controller>
        public IEnumerable<MainGoal> Get()
        {
            var goals = mainGoalRepository.GetAllGoalsWithDependencies();
            return goals;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]MainGoal mainGoal)
        {
            mainGoalRepository.Add(mainGoal);
            
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}