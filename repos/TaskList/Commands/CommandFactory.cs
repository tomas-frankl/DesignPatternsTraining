using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Commands
{
    public class CommandFactory
    {
        public CommandFactory(ITaskListModel model)
        {
            Model = model;
        }

        private ITaskListModel Model { get; set; }

        public ICommand Add(TaskItem item)
        {
            return new AddCommand() { Item = item, Receiver = Model };
        }

        public ICommand Delete(TaskItem item)
        {
            return new DeleteCommand() { Item = item, Receiver = Model };
        }

        public ICommand Edit(TaskItem item)
        {
            return new EditCommand() { Item = item, Receiver = Model };
        }
    }
}
