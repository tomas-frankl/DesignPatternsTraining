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
            var invoker = new Invoker();

            var cmdList = new List<ICommand<Calc>>()
            {
                new PlusCommand() { X = 5 },
                new PlusCommand() { X = 6 }
            };
            invoker.Execute(cmdList);

            //... do somethig else

            var cmdGetResult = new GetResultCommand() {};
            invoker.Execute(cmdGetResult);

            Console.WriteLine(cmdGetResult.Result);
        }
    }
}
