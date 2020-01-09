using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterAndPipes
{

    class Program
    {
        static void Main(string[] args)
        {

            var pipe1 = new Pipe("p1");
            var pipe2 = new Pipe("p2");
            var pipe3 = new Pipe("p3");
            
            var f1 = new PriceFilter() { InPipe = pipe1, OutPipe = pipe2 };
            var f2 = new DiscountFilter() { InPipe = pipe2, OutPipe = pipe3 };

            var o1 = new Order() { Customer = "gopas", Price = 2000000, Text = "slon" };
            var o2 = new Order() { Customer = "tieto", Price = 500000, Text = "slon" };
            var o3 = new Order() { Customer = "xxx", Price = 1500, Text = "krecek" };

            pipe1.Put(o1);
            pipe1.Put(o2);
            pipe1.Put(o3);

            while(true)
            {
                if (pipe3.HasMessage)
                {
                    var o = pipe3.Get();
                    Console.WriteLine($"{o.Customer}, {o.Text}, {o.Price}");
                }
            }
        }
    }
}
