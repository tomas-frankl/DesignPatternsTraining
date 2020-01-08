using Ninject;
using System;
using System.Windows.Forms;
using TaskList.Presenters;
using TaskList.Models;
using TaskList.Views;

namespace TaskList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new StandardKernel();
            container.Bind<ITaskListModel>().To<TaskListModel>().InSingletonScope();
            container.Bind<ITaskListPresenter>().To<TaskListPresenter>().InSingletonScope();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TaskListView(container));
        }
    }
}
