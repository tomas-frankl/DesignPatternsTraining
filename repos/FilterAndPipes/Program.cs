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
            var o1 = new Order() { Customer = "gopas", Price = 2000000, Text = "slon" };
            var o2 = new Order() { Customer = "tieto", Price = 500000, Text = "slon" };
            var o3 = new Order() { Customer = "xxx", Price = 1500, Text = "krecek" };

            var p = new Pipeline();
            p.AddFilter<PriceFilter>(3);
            p.AddFilter<DiscountFilter>(2);

            p.InPipe.Put(o1);
            p.InPipe.Put(o2);
            p.InPipe.Put(o3);

            while (true)
            {
                if (p.OutPipe.HasMessage)
                {
                    var o = p.OutPipe.Get();
                    Console.WriteLine($"{o.Customer}, {o.Text}, {o.Price}");
                }
            }
        }
    }
}
