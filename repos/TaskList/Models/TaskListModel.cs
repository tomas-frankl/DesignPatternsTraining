using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList.Models
{
    public class TaskListModel : ITaskListModel
    {
        private List<TaskItem> taskList = new List<TaskItem>();

        public TaskListModel()
        {
            Add(new TaskItem() { Id = Guid.NewGuid(), Description = "postavit dům", Done = false });
            Add(new TaskItem() { Id = Guid.NewGuid(), Description = "zplodit syna", Done = true });
            Add(new TaskItem() { Id = Guid.NewGuid(), Description = "zasadit strom", Done = false });
        }

        public void Add(TaskItem item)
        {
            taskList.Add(item);
        }

        public void Delete(TaskItem item)
        {
            taskList.RemoveAll(t => t.Id == item.Id);
        }

        public void Update(TaskItem item)
        {
            //var current = taskList.FirstOrDefault(t => t.Id == item.Id);
            //current = item;

            var idx = taskList.FindIndex(t => t.Id == item.Id);
            taskList.RemoveAt(idx);
            taskList.Insert(idx, item);
        }

        public IEnumerable<TaskItem> GetEnumerator()
        {
            return taskList.AsEnumerable();
        }

        public TaskItem Get(Guid id)
        {
            return taskList.FirstOrDefault(t => t.Id == id);
        }
       
    }
}
