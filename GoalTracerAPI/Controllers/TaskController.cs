using ApplicationCore.Entities;
using GoalTracerAPI.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GoalTracerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        private ITaskRepository taskRepository;
        private ITaskAdder taskAdder;

        public TaskController(ITaskRepository taskRepository,ITaskAdder taskAdder)
        {
            this.taskRepository = taskRepository;
            this.taskAdder = taskAdder;
        }

        // GET api/<controller>
        public IEnumerable<Task> Get()
        {
            return taskRepository.GetAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]AddTaskRequest toAdd)
        {
            taskAdder.AddTask(toAdd);
        }

        [HttpPost]
        [Route("[controller]/CompleteTask")]
        public void CompleteTask([FromBody]Task task)
        {
            task.Completed = true;
            taskRepository.Update(task);
        }
    }

    public class AddTaskRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int DependencyId { get; set; }
    }
}