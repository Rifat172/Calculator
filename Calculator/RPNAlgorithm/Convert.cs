using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNAlgorithm
{
    public static class Convert
    {
        /// <summary>
        /// Конвертирует массив строк Инфиксной нотации, в массив строк Постфиксной нотации
        /// </summary>
        /// <param name="exp">Исходный массив строк</param>
        /// <returns></returns>
        public static string[] ToRPN(string[] exp)
        {
            List<string> OutPut = new List<string>();
            Dictionary<string, short> PriorityTable = new Dictionary<string, short>();
            Stack<string> stack = new Stack<string>();
            InitPriorityTable(PriorityTable);
            stack.Push("#");
            foreach (string CurrentStr in exp)
            {
                if (CurrentStr == "(")
                {
                    stack.Push(CurrentStr);
                }
                else if (CurrentStr == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        OutPut.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (double.TryParse(CurrentStr, out double value))
                {
                    OutPut.Add(CurrentStr);
                }
                else
                {
                    if (LeftOperationPriorityMoreThanRight(exp[i], stack.Peek(), PriorityTable))
                    {
                        stack.Push(CurrentStr);
                    }
                    else
                    {
                        string temp;
                        if (LeftOperationPriorityMoreThanRight(temp = stack.Pop(), stack.Peek(), PriorityTable))
                        {
                            OutPut.Add(temp);
                            stack.Push(CurrentStr);
                        }
                    }
                }
            }
            while (stack.Count != 1)
                OutPut.Add(stack.Pop());
            return OutPut.ToArray();
        }

        private static bool LeftOperationPriorityMoreThanRight(string left, string right, Dictionary<string, short> priorityTable)
        {
            if (Math.Max(priorityTable[left], priorityTable[right]) == priorityTable[left])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void InitPriorityTable(Dictionary<string, short> priorityTable)
        {
            priorityTable.Add("#", 0);
            priorityTable.Add("(", 0);
            priorityTable.Add(")", 0);
            priorityTable.Add("+", 1);
            priorityTable.Add("-", 1);
            priorityTable.Add("*", 2);
            priorityTable.Add("/", 2);
        }
    }
}
