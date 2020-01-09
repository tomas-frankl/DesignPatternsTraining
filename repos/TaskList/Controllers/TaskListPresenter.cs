using System;
using TaskList.Commands;
using TaskList.Models;

namespace TaskList.Presenters
{
    public class TaskListPresenter : ITaskListPresenter
    {
        private ITaskListModel model;
        public ITaskListView<TaskItem> view;
        private Invoker invoker = new Invoker();
        private CommandFactory cmdFactory;

        public ITaskListView<TaskItem> View { 
            get { return this.view; } 
            set { this.view = value; Refresh();} 
        }

        public TaskListPresenter(ITaskListModel model)
        {
            this.model = model;
            cmdFactory = new CommandFactory(model);
        }

        public void Refresh()
        {
            View.OnListUpdated(model.GetEnumerator());
        }

        public void Add(TaskItem item)
        {
            invoker.Execute(cmdFactory.Add(item));
            Refresh();
        }

        public void Delete(TaskItem item)
        {
            invoker.Execute(cmdFactory.Delete(item));
            Refresh();
        }

        public void Update(TaskItem item)
        {
            invoker.Execute(cmdFactory.Edit(item));
            Refresh();
        }


        public void AddAction()
        {
            var item = new TaskItem() { Id = Guid.Empty, Description = "<enter description>", Done = false };
            View.OnAddAction(item);
        }

        public void DeleteAction(Guid id)
        {
            var item = model.Get(id);
            View.OnDeleteAction(item);
        }

        public void EditAction(Guid id)
        {
            var item = model.Get(id);
            var clone = new TaskItem() { Id = item.Id, Description = item.Description, Done = item.Done };
            View.OnEditAction(clone);
        }

        public void ToggleAction(Guid id)
        {
            var item = model.Get(id);
            var clone = new TaskItem() { Id = item.Id, Description = item.Description, Done = !item.Done };
            Update(clone);
        }

        public void UndoAction()
        {
            invoker.Compensate();
            Refresh();
        }
    }
}
