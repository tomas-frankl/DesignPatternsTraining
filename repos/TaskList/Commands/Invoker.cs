using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Commands
{
    public class Invoker
    {
        private Stack<ICommand> cmdStack = new Stack<ICommand>();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            cmdStack.Push(cmd);
        }

        public void Compensate()
        {
            if(cmdStack.Any())
            {
                cmdStack.Pop().Compensate();
            }
        }
    }
}
