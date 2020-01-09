using System;
using TaskList.Models;

namespace TaskList.Commands
{
    public class EditCommand : ICommand
    {
        public ITaskListModel Receiver { get; set; }

        public TaskItem Item { private get; set; }

        private TaskItem OriginalItem { get; set; }

        public void Compensate()
        {
            Receiver.Update(OriginalItem);
        }

        public void Execute()
        {
            OriginalItem = Receiver.Get(Item.Id);
            Receiver.Update(Item);
        }
    }
}
