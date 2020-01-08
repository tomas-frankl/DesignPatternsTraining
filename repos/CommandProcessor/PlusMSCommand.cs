using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    public class PlusMSCommand : ICommand
    {
        int ms;

        public Calc Receiver { get; set; }

        public bool IsCompensable => true;

        public void Execute()
        {
            ms = Receiver.PlusMS();
        }
        public void Compensate()
        {
            Receiver.Plus(-ms);
        }

    }
}
