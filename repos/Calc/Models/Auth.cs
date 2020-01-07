using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    class Auth : IAuth
    {
        public bool Login(string userName, string password)
        {
            return (userName == "t" && password == "f");
        }
    }
}
