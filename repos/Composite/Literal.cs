using System.Collections.Generic;

namespace Composite
{
    public class Literal : IExpression
    {
        double value;

        public Literal(double value)
        {
            this.value = value;
        }

        public double Interpret(IDictionary<string, double> context)
        {
            return value;
        }
    }
}
