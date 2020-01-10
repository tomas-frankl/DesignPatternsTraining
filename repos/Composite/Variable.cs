using System.Collections.Generic;

namespace Composite
{
    public class Variable : IExpression
    {
        string name;

        public Variable(string name)
        {
            this.name = name;
        }

        public double Interpret(IDictionary<string, double> context)
        {
            return context[name];
        }
    }
}
