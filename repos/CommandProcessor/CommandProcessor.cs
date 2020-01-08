using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    public class CommandProcessor
    {
        Stack<ICommand> commandStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            if (command.IsCompensable)
                commandStack.Push(command);
        }

        public void CompensateLast()
        {
            if (commandStack.Any())
                commandStack.Pop().Compensate();
        }

    }
}
