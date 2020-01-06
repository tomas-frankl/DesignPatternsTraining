using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDemo
{
    class ClassA
    {
        protected virtual ClassB CreateClassB() => new ClassB();

        public void UseB()
        {
            var b = CreateClassB();
            b.Use();
        }
    }
}
