using System;

namespace _04SimpleFactoryAndSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = SingletonFactory.Instance;
            singleton1.Use();
            var singleton2 = SingletonFactory.Instance;
            singleton2.Use();

            if (singleton1 == singleton2)
                Console.WriteLine("OK");

            var factory = new SingletonFactory();
            var singletonA = factory.CreateSingleton();
            var singletonB = factory.CreateSingleton();

            if (singletonA == singletonB)
                Console.WriteLine("OK");

        }
    }
}
