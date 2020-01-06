using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    class ClassB : IClassB
    {
        private IClassA classA;

        public ClassB(IClassA classA)
        {
            this.classA = classA;
        }

        public void UseB() 
        {
            classA.UseA();   
        }

        public IClassA GetClassA()
        {
            return classA;
        }
    }
}
