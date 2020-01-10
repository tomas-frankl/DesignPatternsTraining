using System.Collections.Generic;

namespace Composite
{
    public interface IExpression
    {
        double Interpret(IDictionary<string, double> context);
    }
}
