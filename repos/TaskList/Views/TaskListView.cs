using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskList.Presenters;
using TaskList.Models;

namespace TaskList.Views
{
    public partial class TaskListView : Form, ITaskListView<TaskItem>
    {
        private IKernel container;
        private ITaskListPresenter presenter;

        public TaskListView(IKernel container)
        {
            this.container = container;
            this.presenter = container.Get<ITaskListPresenter>();

            InitializeComponent();

            this.presenter.View = this;
        }

        public void OnListUpdated(IEnumerable<TaskItem> list)
        {
            listBoxTasks.Items.Clear();
            foreach (var item in list)
            {
                listBoxTasks.Items.Add(item);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            UndoAction();
        }

        private void listBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            ToggleAction();
        }

        private void AddAction()
        {
            presenter.AddAction();
        }

        private void DeleteAction()
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
                presenter.DeleteAction(item.Id);
        }

        private void EditAction()
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
                presenter.EditAction(item.Id);
        }

        private void UndoAction()
        {
            presenter.UndoAction();
        }

        private void ToggleAction()
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
                presenter.ToggleAction(item.Id);
        }

        public void OnAddAction(TaskItem item)
        {
            var detailsView = new TaskDetailsView(container, item);
            detailsView.Show();
        }

        public void OnEditAction(TaskItem item)
        {
            var detailsView = new TaskDetailsView(container, item);
            detailsView.Show();
        }

        public void OnDeleteAction(TaskItem item)
        {
            if (MessageBox.Show($"Delete item \"{item.Description}\"", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenter.Delete(item);
            }
        }

        private void listBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                var item = (TaskItem)listBoxTasks.Items[e.Index];

                Brush myBrush = item.Done ? Brushes.DarkGray : Brushes.Black;
                e.Graphics.DrawString(item.Description, e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }

        private void listBoxTasks_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert: AddAction(); break;
                case Keys.Delete: DeleteAction(); break;
                case Keys.Enter: EditAction(); break;
                case Keys.Back: UndoAction(); break;
                case Keys.Space: ToggleAction(); break;
            }
        }
    }
}
