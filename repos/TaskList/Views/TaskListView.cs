using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskList.Controllers;
using TaskList.Models;

namespace TaskList.Views
{
    public partial class TaskListView : Form, ITaskListView<TaskItem>
    {
        private IKernel container;
        private ITaskListController controller;

        public TaskListView(IKernel container)
        {
            this.container = container;
            this.controller = container.Get<ITaskListController>();
            
            InitializeComponent();

            this.controller.View = this;
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
            controller.AddAction();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
                controller.DeleteAction(item.Id);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
                controller.EditAction(item.Id);
        }

        private void listBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            var item = (TaskItem)listBoxTasks.SelectedItem;
            if (item != null)
            {
                item.Done = !item.Done;
                controller.Update(item);
            }
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
                controller.Delete(item);
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
    }
}
