using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Commands
{
    public interface ICommand
    {
        ITaskListModel Receiver { get; set; }

        void Execute();
        void Compensate();
    }
}
