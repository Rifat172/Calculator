using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNAlgorithm
{
    public static class Convert
    {
        public static string[] ToRPN(string[] exp)
        {
            double value = 0;
            List<string> OutPut = new List<string>();
            Dictionary<string, short> PriorityTable = new Dictionary<string, short>();
            Stack<string> stack = new Stack<string>();
            InitPriorityTable(PriorityTable);
            stack.Push("#");
            for (int i = 0; i < exp.Length; i++)
            {
                if(exp[i]=="(")
                {
                    stack.Push(exp[i]);
                }
                else if(exp[i]==")")
                {
                    while(stack.Peek()!="(")
                    {
                        OutPut.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (double.TryParse(exp[i], out value))
                {
                    OutPut.Add(exp[i]);
                }
                else
                {
                    if(LeftOperationPriorityMoreThanRight(exp[i],stack.Peek(),PriorityTable))
                    {
                        stack.Push(exp[i]);
                    }
                    else
                    {
                        string temp;
                        if(LeftOperationPriorityMoreThanRight(temp=stack.Pop(),stack.Peek(),PriorityTable))
                        {
                            OutPut.Add(temp);
                            stack.Push(exp[i]);
                        }
                    }
                }
            }
            while (stack.Count != 1)
                OutPut.Add(stack.Pop());
            return OutPut.ToArray();
        }

        private static bool LeftOperationPriorityMoreThanRight(string left, string right, Dictionary<string,short> priorityTable)
        {
            if(Math.Max(priorityTable[left],priorityTable[right])==priorityTable[left])
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
