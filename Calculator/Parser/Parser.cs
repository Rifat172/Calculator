using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SourceExpression
{
    public static class Parser
    {
        /// <summary>
        /// Возварщает массив
        /// </summary>
        /// <param name="exp">Исходная строка</param>
        /// <returns></returns>
        public static string[] Parse(string exp)
        {            
            List<string> arrExpression = new List<string>();

            Regex regex = new Regex(@"\+|\-|\/|\*|\(|\)|[0-9]+\.?[0-9]+|[0-9]+");//регулярное вырожение

            if (exp.Contains(","))
            {
                exp = Replace(exp, @"\,", ".");
            }

            MatchCollection matches = regex.Matches(exp);

            foreach (Match match in matches)
            {
                arrExpression.Add(match.Value);
            }
            return arrExpression.ToArray();
        }

        /// <summary>
        /// Проверяет можно ли разбить строку на массив
        /// </summary>
        /// <param name="exp">Исходная строка</param>
        /// <param name="result">Результат - массив строк</param>
        /// <returns></returns>
        public static bool TryParse(string exp, out string[] result)
        {
            if(Regex.IsMatch(exp,@"[a-z]+|[а-я]",RegexOptions.IgnoreCase))
            {
                result = null;
                return false;
            }
            result = Parse(exp);
            return true;
        }
        private static string Replace(string input,string pattern, string target)
        {
            Regex regex = new Regex(pattern);
            return regex.Replace(input, target);
        }
    }
}