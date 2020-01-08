using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    public class GetResultCommand : ICommand
    {
        public Calc Receiver { get; set; }
        public double Result { get; private set; }
        public bool IsCompensable => false;

        public void Execute()
        {
            Result = Receiver.Result;
        }
        public void Compensate()
        {
            throw new NotImplementedException();
        }
    }
}
