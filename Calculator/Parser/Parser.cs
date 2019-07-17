using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SourceExpression
{
    public class Parser
    {
        string[] ArrayExpression;
        public string[] Parse(string exp)
        {
            ArrayExpression = foo(exp);
            return ArrayExpression;
        }
        private string[] foo(string exp)
        {
            List<string> arr = new List<string>();

            Regex regex = new Regex(@"\+|\-|\/|\*|\(|\)|[0-9]+\.?[0-9]+|[0-9]+");

            var matches = regex.Matches(exp);

            foreach (Match match in matches)
            {
                arr.Add(match.Value);
            }
            return arr.ToArray();
        }
    }
}