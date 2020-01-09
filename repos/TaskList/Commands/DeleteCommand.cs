using System;
using TaskList.Models;

namespace TaskList.Commands
{
    public class DeleteCommand : ICommand
    {
        public ITaskListModel Receiver { get; set; }

        public TaskItem Item { private get; set; }
        public int Index { private get; set; }

        public void Compensate()
        {
            Receiver.Insert(Item, Index);
        }

        public void Execute()
        {
            Index = Receiver.Delete(Item);
        }
    }
}
