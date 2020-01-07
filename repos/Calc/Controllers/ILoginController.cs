using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Controllers
{
    public interface ILoginController
    {
        void LoginAction(string userName, string password);
    }
}
