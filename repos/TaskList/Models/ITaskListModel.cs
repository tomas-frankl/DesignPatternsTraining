using System;
using System.Collections.Generic;

namespace TaskList.Models
{
    public interface ITaskListModel
    {
        void Add(TaskItem item);
        void Insert(TaskItem item, int index);
        int Delete(TaskItem item);
        IEnumerable<TaskItem> GetEnumerator();
        void Update(TaskItem item);
        TaskItem Get(Guid id);
    }
}