﻿using System;
using TaskList.Models;

namespace TaskList.Controllers
{
    public interface ITaskListController
    {
        ITaskListView<TaskItem> View { get; set; }

        void Refresh();
        void AddAction();
        void DeleteAction(Guid id);
        void EditAction(Guid id);
        
        void Add(TaskItem item);
        void Update(TaskItem item);
        void Delete(TaskItem item);
    }
}
