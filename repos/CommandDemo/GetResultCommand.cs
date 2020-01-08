using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public class GetResultCommand : CalcCommand
    {
        public double Result { get; private set; }

        public override void Execute()
        {
            Result = Receiver.Result;
        }
    }
}
