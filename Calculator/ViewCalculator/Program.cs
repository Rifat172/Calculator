using System;
using RPNAlgorithm;
using SourceExpression;

namespace ViewCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в мега-крутой калькулятор который может в скобки");
            Console.WriteLine("Введите ваше выражение: ");
            string Expression = Console.ReadLine();
            Algorithm alg = new Algorithm(RPNAlgorithm.Convert.ToRPN(Parser.Parse(Expression)));
            Console.WriteLine($"{Expression}={alg.Calc()}");
        }
    }
}
