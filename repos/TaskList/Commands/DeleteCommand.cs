using System;
using TaskList.Models;

namespace TaskList.Commands
{
    public class DeleteCommand : ICommand
    {
        public ITaskListModel Receiver { get; set; }

        public TaskItem Item { private get; set; }

        public void Compensate()
        {
            Receiver.Add(Item);
        }

        public void Execute()
        {
            Receiver.Delete(Item);
        }
    }
}
