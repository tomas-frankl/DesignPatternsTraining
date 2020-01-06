using System;

namespace _04SimpleFactoryAndSingleton
{
    class SingletonFactory : ISingletonFactory
    {
        static Lazy<SingletonClass> instance = new Lazy<SingletonClass>(() => new SingletonClass());

        public ISingleton CreateSingleton()
        {
            return instance.Value;
        }

        static public ISingleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}
