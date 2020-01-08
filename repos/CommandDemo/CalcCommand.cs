using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public abstract class CalcCommand :ICommand<Calc>
    {
        [NonSerialized]
        public Calc receiver;

        public Calc Receiver { get { return receiver; } set { receiver = value;  } }

        public abstract void Execute();
    }
}
