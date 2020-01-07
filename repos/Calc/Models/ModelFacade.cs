using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    //typicky jenom deleguje funcionalitu na nekterou z komponent
    public class ModelFacade : IModelFacade
    {
        ICalcModel calcModel;
        ILogger logger;
        IAuth auth;

        public ModelFacade(ICalcModel calcModel, ILogger logger, IAuth auth)
        {
            this.calcModel = calcModel;
            this.logger = logger;
            this.auth = auth;
        }

        public double Result => calcModel.Result;

        public IEnumerable<string> LogItems => logger.Items;

        public void Minus(double obj)
        {
            calcModel.Minus(obj);
            logger.Write($"Minus operation, operator:{obj}, result:{calcModel.Result}");
        }

        public void Plus(double obj)
        {
            calcModel.Plus(obj);
            logger.Write($"Plus operation, operator:{obj}, result:{calcModel.Result}");
        }

        public bool Login(string userName, string password)
        {
            return auth.Login(userName, password);
        }
    }
}
