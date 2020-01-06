using System;

namespace SingletonDemo
{
    public sealed class SingletonNew
    {
        private static Lazy<SingletonNew> lazyInstance 
            = new Lazy<SingletonNew>( () => new SingletonNew(), true);

        public static SingletonNew Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }

        private SingletonNew() { }

        public void DoStuff() { System.Console.WriteLine("yyy"); }
    }
}
