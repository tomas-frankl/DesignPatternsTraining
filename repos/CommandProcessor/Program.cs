using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            var calc = new Calc();
            var cp = new CommandProcessor();
            cp.ExecuteCommand(new PlusCommand() { Receiver = calc, X = 5 });
            cp.ExecuteCommand(new PlusCommand() { Receiver = calc, X = 6 });
            cp.ExecuteCommand(new PlusMSCommand() { Receiver = calc });

            var getResult = new GetResultCommand() { Receiver = calc };

            cp.ExecuteCommand(getResult);
            Console.WriteLine(getResult.Result);

            cp.CompensateLast();

            cp.ExecuteCommand(getResult);
            Console.WriteLine(getResult.Result);

            cp.CompensateLast();

            cp.ExecuteCommand(getResult);
            Console.WriteLine(getResult.Result);
        }
    }
}
