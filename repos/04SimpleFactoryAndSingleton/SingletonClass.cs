using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SimpleFactoryAndSingleton
{
    class SingletonClass : ISingleton
    {
        public void Use()
        {
            Console.WriteLine("SingletonClass used");
        }
    }
}
