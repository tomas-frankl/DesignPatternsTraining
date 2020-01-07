using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    public interface IModelFacade
    {
        double Result { get; }
        IEnumerable<string> LogItems { get; }
        void Plus(double obj);
        void Minus(double obj);
    }
}
