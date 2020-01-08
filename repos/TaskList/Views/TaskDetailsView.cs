using Ninject;
using System;
using System.Windows.Forms;
using TaskList.Controllers;
using TaskList.Models;

namespace TaskList.Views
{
    public partial class TaskDetailsView : Form
    {

        private IKernel container;
        private ITaskListController controller;
        private TaskItem item;

        public TaskDetailsView(IKernel container, TaskItem item)
        {
            this.container = container;
            this.item = item;
            this.controller = container.Get<ITaskListController>();

            InitializeComponent();

            textBoxDescription.Text = item.Description;
            checkBoxDone.Checked = item.Done;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (item.Id == Guid.Empty)
            {
                controller.Add(new TaskItem() { Id = Guid.NewGuid(), Description = textBoxDescription.Text, Done = checkBoxDone.Checked });
            }
            else
            {
                item.Description = textBoxDescription.Text;
                item.Done = checkBoxDone.Checked;
                controller.Update(item);
            }

            Close();
        }
    }
}
