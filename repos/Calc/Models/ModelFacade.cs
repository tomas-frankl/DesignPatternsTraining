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

        public ModelFacade(ICalcModel calcModel, ILogger logger)
        {
            this.calcModel = calcModel;
            this.logger = logger;
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
    }
}
