using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Calc.Models;
using Calc.Controllers;
using Calc.Views;
using Ninject;

namespace Calc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new StandardKernel();
            
            //models
            container.Bind<ICalcModel>().To<CalcModel>();
            container.Bind<ILogger>().To<Logger>().InSingletonScope();
            container.Bind<IAuth>().To<Auth>().InSingletonScope();
            container.Bind<IModelFacade>().To<ModelFacade>().InSingletonScope();

            //view
            container.Bind<IView>().To<ErrorView>().InSingletonScope().Named("Error");
            container.Bind<IView>().To<LoginWindow>().InSingletonScope().Named("Login");
            container.Bind<IView>().To<LogWindow>().InSingletonScope().Named("Log");
            container.Bind<IView>().To<MainWindow>().InSingletonScope().Named("Main");

            //controllers
            container.Bind<ICalcController>().To<CalcController>().InSingletonScope();
            container.Bind<ILoginController>().To<LoginController>().InSingletonScope();
            container.Bind<IViewHandler>().To<WpfViewHandler>().InSingletonScope();

            //display login window
            var LoginView = container.Get<IView>("Login");
            ((Window)LoginView).Show();
        }
    }
}
