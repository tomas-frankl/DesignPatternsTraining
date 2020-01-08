using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public class Invoker
    {
        Calc receiver;

        public Invoker()
        {
            this.receiver = new Calc(); ;
        }

        public void Execute(ICommand<Calc> cmd)
        {
            if (cmd.Receiver == null)
                cmd.Receiver = receiver;
            cmd.Execute();
        }

        public void Execute(IEnumerable<ICommand<Calc>> cmds)
        {
            foreach (var cmd in cmds)
            {
                //provadeci politika
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                {
                    Execute(cmd);
                }
            }
        }

    }
}
