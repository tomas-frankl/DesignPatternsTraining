using System.Collections.Generic;

namespace Composite
{
    public abstract class BinaryOperator : IExpression
    {
        protected IExpression operator1;
        protected IExpression operator2;

        protected BinaryOperator(IExpression operator1, IExpression operator2)
        {
            this.operator1 = operator1;
            this.operator2 = operator2;
        }

        public abstract double Interpret(IDictionary<string, double> context);
    }
}
