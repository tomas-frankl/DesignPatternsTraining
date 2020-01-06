using System;

namespace AbstractFactory
{
    class RedSquare : ISquare
    {
        public void UseSquare()
        {
            Console.WriteLine("RedSquareUsed");
        }
    }
}
