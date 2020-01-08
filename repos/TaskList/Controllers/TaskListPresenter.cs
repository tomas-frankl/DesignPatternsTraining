using System;
using TaskList.Models;

namespace TaskList.Presenters
{
    public class TaskListPresenter : ITaskListPresenter
    {
        private ITaskListModel model;
        public ITaskListView<TaskItem> view;

        public ITaskListView<TaskItem> View { 
            get { return this.view; } 
            set { this.view = value; Refresh();} 
        }

        public TaskListPresenter(ITaskListModel model)
        {
            this.model = model;
        }

        public void Refresh()
        {
            View.OnListUpdated(model.GetEnumerator());
        }

        public void Add(TaskItem item)
        {
            model.Add(item);
            Refresh();
        }

        public void Delete(TaskItem item)
        {
            model.Delete(item);
            Refresh();
        }

        public void Update(TaskItem item)
        {
            model.Update(item);
            Refresh();
        }


        public void AddAction()
        {
            var item = new TaskItem() { Id = Guid.Empty, Description = "<enter description>", Done = false };
            View.OnEditAction(item);
        }

        public void DeleteAction(Guid id)
        {
            var item = model.Get(id);
            View.OnDeleteAction(item);
        }

        public void EditAction(Guid id)
        {
            var item = model.Get(id);
            View.OnAddAction(item);
        }
    }
}
