using System;
using TaskList.Models;

namespace TaskList.Commands
{
    public class AddCommand : ICommand
    {
        public ITaskListModel Receiver { get; set; }

        public TaskItem Item { private get; set; }

        public void Compensate()
        {
            Receiver.Delete(Item);
        }

        public void Execute()
        {
            Receiver.Add(Item);
        }
    }
}
