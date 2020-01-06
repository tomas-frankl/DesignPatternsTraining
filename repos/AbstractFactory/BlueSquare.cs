using System;

namespace AbstractFactory
{
    class BlueSquare : ISquare
    {
        public void UseSquare()
        {
            Console.WriteLine("BlueSquareUsed");
        }
    }
}
