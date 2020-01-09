using System;
using TaskList.Models;

namespace TaskList.Presenters
{
    public interface ITaskListPresenter
    {
        ITaskListView<TaskItem> View { get; set; }

        void Refresh();
        void AddAction();
        void DeleteAction(Guid id);
        void EditAction(Guid id);
        void ToggleAction(Guid id);
        void UndoAction();


        void Add(TaskItem item);
        void Update(TaskItem item);
        void Delete(TaskItem item);
    }
}
