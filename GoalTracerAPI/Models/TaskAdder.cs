using ApplicationCore.Entities;
using GoalTracerAPI.Controllers;
using Infrastructure.Data;
using System.Collections.Generic;

namespace GoalTracerAPI.Models
{
    public interface ITaskAdder
    {
        void AddTask(AddTaskRequest addTaskRequest);
    }

    public class TaskAdder : ITaskAdder
    {
        private ITaskRepository taskRepository;

        public TaskAdder(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void AddTask(AddTaskRequest addTaskRequest)
        {
            var toAdd = new ApplicationCore.Entities.Task
            {
                Name = addTaskRequest.Name,
                Date = addTaskRequest.Date
            };

            if (addTaskRequest.DependencyId == 0)
            {
                taskRepository.Add(toAdd);
            }
            else
            {
                var parent = taskRepository.GetById(addTaskRequest.DependencyId);

                if (parent.DependencyTasks == null)
                    parent.DependencyTasks = new List<Task>();

                parent.DependencyTasks.Add(toAdd);

                taskRepository.Update(parent);
            }
        }
    }
}