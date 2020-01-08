using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    public class PlusCommand : ICommand
    {
        public Calc Receiver { get; set; }
        public double X { get; set; }

        public bool IsCompensable => true;

        public void Execute()
        {
            Receiver.Plus(X);
        }
        public void Compensate()
        {
            Receiver.Plus(-X);
        }

    }
}
