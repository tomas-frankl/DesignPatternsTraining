using Ninject;
using Autofac;
using System;

namespace InversionOfControl
{
    class Program
    {
        static void DependencyInjection_NInject()
        {
            var container = new StandardKernel();
            container.Bind<IClassA>().To<ClassA>().InSingletonScope();
            container.Bind<IClassB>().ToSelf();

            var a1 = container.Get<IClassA>();
            var a2 = container.Get<IClassA>();
            var b1 = container.Get<ClassB>();
            var a3 = b1.GetClassA();

            if (a1 == a2 && a2 == a3)
            {
                Console.WriteLine("OK");
            }
        }

        static void DependencyInjection_Autofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ClassA>().As<IClassA>().SingleInstance();
            containerBuilder.RegisterType<ClassB>().AsSelf();
            var container = containerBuilder.Build();

            var a1 = container.Resolve<IClassA>();
            var a2 = container.Resolve<IClassA>();
            var b1 = container.Resolve<ClassB>();
            var a3 = b1.GetClassA();

            if (a1 == a2 && a2 == a3)
            {
                Console.WriteLine("OK");
            }
        }

        static void Main(string[] args)
        {
            DependencyInjection_NInject();
            DependencyInjection_Autofac();
        }

    }
}
