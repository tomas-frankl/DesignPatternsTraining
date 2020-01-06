using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDemo
{
    class BetterClassA : ClassA
    {
        protected virtual BetterClassB CreateClassB() => new BetterClassB();
    }
}
