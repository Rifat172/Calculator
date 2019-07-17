using System;
using System.Collections;
using System.Collections.Generic;

namespace RPNAlgorithm
{
    public class Algorithm
    {
        string[] Expression;
        double Result { get { return Result; } }
        Dictionary<string, short?> PriorityTable;


        public Algorithm(string[] Expression)
        {
            this.Expression = Expression;

            IninPriorityTable();
        }

        private void IninPriorityTable()
        {
            PriorityTable = new Dictionary<string, short?>();
            PriorityTable.Add("+", 1);
            PriorityTable.Add("-", 1);
            PriorityTable.Add("/", 2);
            PriorityTable.Add("*", 2);
            PriorityTable.Add("(", null);
            PriorityTable.Add(")", null);
        }

        public double Calc()
        {
            Stack<double> Operands = new Stack<double>();
            Stack<string> Operations = new Stack<string>();
            for (int i = 0; i < Expression.Length; i++)
            {
                double number = 0;
                if (double.TryParse(Expression[i], out number))
                {
                    Operands.Push(number);
                }
                else
                {
                    if (Operations.Count == 0)
                    {
                        Operations.Push(Expression[i]);
                        continue;
                    }
                    else
                    {

                        if (IsLeftPriorityMoreThanRight(Expression[i], Operations.Peek()))
                        {
                            Operations.Push(Expression[i]);
                        }
                        else
                        {
                            DoOperation(Operands, Expression[i]);
                        }
                    }
                }
            }
            return 6;
        }

        private void DoOperation(Stack<double> operands, string operation)
        {
            switch (operation)
            {
                case "+":
                    operands.Push(operands.Pop() + operands.Pop());
                    break;
                case "-":
                    operands.Push(operands.Pop() - operands.Pop());
                    break;
                case "*":
                    operands.Push(operands.Pop() * operands.Pop());
                    break;
                case "/":
                    operands.Push(operands.Pop() / operands.Pop());
                    break;
                default:
                    return;
            }
        }

        private bool IsLeftPriorityMoreThanRight(string left, string right)
        {
            if (PriorityTable[left] == null)
                return true;
        }
    }
}