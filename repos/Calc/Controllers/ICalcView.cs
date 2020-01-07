using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Controllers
{
    //callback interface - proto Controller predepisuje vzhled rozhrani
    public interface ICalcView
    {
        void UpdateView(string result);
    }
}
