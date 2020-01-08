using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public class PlusCommand : CalcCommand
    {
        public double X { get; set; }

        public override void Execute()
        {
            Receiver.Plus(X);
        }
    }
}
