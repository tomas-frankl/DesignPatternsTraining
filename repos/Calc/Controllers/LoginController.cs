using Calc.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc.Controllers
{
    class LoginController : ILoginController
    {
        IModelFacade model;
        IView mainView { get; set; }
        IView errorView { get; set; }

        IViewHandler viewHandler;

        IKernel container;

        public LoginController(IKernel container)
        {
            this.container = container;
            this.model = container.Get<IModelFacade>();
            this.viewHandler = container.Get<IViewHandler>();
        }

        public void LoginAction(string userName, string password)
        {
            if(model.Login(userName, password))
            {
                //hide login
                var loginView = container.Get<IView>("Login");
                viewHandler.Hide(loginView);

                if (!viewHandler.IsReady(mainView))
                {
                    
                    mainView = container.Get<IView>("Main");
                    viewHandler.Show(mainView);
                }
            }
            else
            {
                //show error
                container.Get<IView>("Error").UpdateView();
            }
        }
    }
}
