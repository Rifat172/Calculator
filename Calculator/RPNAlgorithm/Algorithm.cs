using System;
using System.Collections.Generic;

namespace RPNAlgorithm
{
    public class Algorithm
    {
        string[] Expression;
        public Algorithm(string[] Expression)
        {
            this.Expression = Expression;
        }
        public double Calc()
        {
            Stack<double> stack = new Stack<double>();
            double value;
            for(int i = 0; i < Expression.Length; i++)
            {
                if(double.TryParse(Expression[i],out value))
                {
                    stack.Push(value);
                }
                else
                {
                    double topOperand = stack.Pop();
                    double bottomOperand = stack.Pop();
                    stack.Push(DoOperation(topOperand, bottomOperand, Expression[i]));
                }
            }
            return stack.Pop();
        }

        private double DoOperation(double topOperand, double bottomOperand, string Operation)
        {
            switch (Operation)
            {
                case "+":
                    return bottomOperand + topOperand;
                case "-":
                    return bottomOperand - topOperand;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}