using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();

            var invoker = new Invoker();

            var cmdList = new List<ICommand>()
            {
                new PlusCommand() { Receiver = calc, X = 5 },
                new PlusCommand() { Receiver = calc, X = 6 }
            };
            invoker.Execute(cmdList);

            //... do somethig else

            var cmdGetResult = new GetResultCommand() { Receiver = calc };
            invoker.Execute(cmdGetResult);

            Console.WriteLine(cmdGetResult.Result);
        }
    }
}
