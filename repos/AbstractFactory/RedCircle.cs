using System;

namespace AbstractFactory
{
    class RedCircle : ICircle
    {
        public void UseCircle()
        {
            Console.WriteLine("RedCircleUsed");
        }
    }
}
