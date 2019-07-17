using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SourceExpression
{
    public static class Parser
    {
        public static string[] Parse(string exp)
        {            
            List<string> arrExpression = new List<string>();

            Regex regex = new Regex(@"\+|\-|\/|\*|\(|\)|[0-9]+\.?[0-9]+|[0-9]+");

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
        public static bool TryParse(string exp, out string[] arrExp)
        {
            if(Regex.IsMatch(exp,@"[a-z]+|[а-я]",RegexOptions.IgnoreCase))
            {
                arrExp = null;
                return false;
            }
            arrExp = Parse(exp);
            return true;
        }
        private static string Replace(string input,string pattern, string target)
        {
            Regex regex = new Regex(pattern);
            return regex.Replace(input, target);
        }
    }
}