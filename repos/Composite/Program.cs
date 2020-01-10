using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 * ( (5 - x) + y ) [x=2, y=4]
            //3 * ( (5 - 2) + 4 ) = 21

            var expression =
                new Product(
                    new Literal(3),
                    new Sum(
                        new Subtract(
                            new Literal(5), 
                            new Variable("x")),
                        new Variable("y")
                    )
               );

            var context = new Dictionary<string, double>() 
            { 
                {"x", 2}, 
                {"y", 4} 
            };

            var result = expression.Interpret(context);
            Console.WriteLine(result);
        }
    }
}
