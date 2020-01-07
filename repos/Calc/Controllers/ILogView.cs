using System.Collections.Generic;

namespace Calc.Controllers
{
    public interface ILogView
    {
        void UpdateView(IEnumerable<string> logItems);
    }
}