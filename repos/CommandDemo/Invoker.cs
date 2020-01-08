using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public class Invoker
    {
        public void Execute(ICommand cmd)
        {
            cmd.Execute();
        }

        public void Execute(IEnumerable<ICommand> cmds)
        {
            foreach (var cmd in cmds)
            {
                //provadeci politika
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                {
                    cmd.Execute();
                }
            }
        }

    }
}
