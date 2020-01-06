using System;

namespace AbstractFactory
{
    class BlueCircle : ICircle
    {
        public void UseCircle()
        {
            Console.WriteLine("BlueCircleUsed");
        }
    }
}
