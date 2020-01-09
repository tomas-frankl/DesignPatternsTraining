using Ninject;
using System;
using System.Windows.Forms;
using TaskList.Presenters;
using TaskList.Models;

namespace TaskList.Views
{
    public partial class TaskDetailsView : Form
    {

        private IKernel container;
        private ITaskListPresenter presenter;
        private TaskItem item;

        public TaskDetailsView(IKernel container, TaskItem item)
        {
            this.container = container;
            this.item = item;
            this.presenter = container.Get<ITaskListPresenter>();

            InitializeComponent();

            textBoxDescription.Text = item.Description;
            checkBoxDone.Checked = item.Done;
        }

        private void SaveAndClose()
        {
            if (item.Id == Guid.Empty)
            {
                presenter.Add(new TaskItem() { Id = Guid.NewGuid(), Description = textBoxDescription.Text, Done = checkBoxDone.Checked });
            }
            else
            {
                item.Description = textBoxDescription.Text;
                item.Done = checkBoxDone.Checked;
                presenter.Update(item);
            }

            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }


        private void TaskDetailsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveAndClose();
        }
    }
}
