using System.Collections.Generic;

namespace Composite
{
    public class Product : BinaryOperator
    {
        public Product(IExpression operator1, IExpression operator2) : base(operator1, operator2)
        {
        }

        public override double Interpret(IDictionary<string, double> context)
        {
            return operator1.Interpret(context) * operator2.Interpret(context);
        }
    }
}
