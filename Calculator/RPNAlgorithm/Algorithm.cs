using System;
using System.Collections.Generic;

namespace RPNAlgorithm
{
    /// <summary>
    /// Алгоритм работает только с Обратной Постфиксной Нотацией(RPN)
    /// </summary>
    public class Algorithm
    {
        string[] Expression;
        public Algorithm(string[] Expression)
        {
            this.Expression = Expression;
        }
        public double Calc()
        {
            Stack<double> stack = new Stack<double>();//стек для работы с числами double
            for (int i = 0; i < Expression.Length; i++)
            {
                if (double.TryParse(Expression[i], out double value))
                {
                    stack.Push(value);
                }
                else
                {
                    Operation(stack, Expression[i]);
                }
            }
            return stack.Pop();
        }

        private void Operation(Stack<double> stack,string Act)
        {
            double topOperand = stack.Pop();
            double bottomOperand = stack.Pop();
            stack.Push(Operation(topOperand, bottomOperand, Act));
        }

        private double Operation(double topOperand, double bottomOperand, string Operation)
        {
            switch (Operation)
            {
                case "+":
                    return bottomOperand + topOperand;
                case "-":
                    return bottomOperand - topOperand;
                case "*":
                    return bottomOperand * topOperand;
                case "/":
                    return bottomOperand / topOperand;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}