using NUnit.Framework;
using SourceExpression;

namespace SourceExpressionTest
{
    [TestFixture]
    class ParserTest
    {
        [TestCase("(2.5+0.5)*2", new string[] { "(", "2.5", "+", "0.5", ")", "*", "2" })]
        [TestCase("(2+0.5)*2.5", new string[] { "(", "2", "+", "0.5", ")", "*", "2.5" })]
        [TestCase("2+2*2", new string[] { "2", "+", "2", "*", "2" })]
        public void Parse_CorrectlyExpression_CorrectlyArray(string input, string[] output)
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse(input);
            Assert.AreEqual(output, ArrayExpression);
        }

        [TestCase("(af2а/поделить0.5)-2.5", new string[] { "(", "2", "/", "0.5", ")", "-", "2.5" })]
        [TestCase("(2,5+0,5)*2", new string[] { "(", "2.5", "+", "0.5", ")", "*", "2" })]
        [TestCase("(2,55+0,5)*2", new string[] { "(", "2.55", "+", "0.5", ")", "*", "2" })]
        [TestCase("Привет", new string[] { })]
        public void Parse_IncorrectlyExpression_CorrectlyArray(string input, string[] output)
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse(input);
            Assert.AreEqual(output, ArrayExpression);
        }

        [TestCase("2плюс2*2", null)]
        public void TryParse_IncorrectlyExpression_ReturnFalse(string input, string[] output)
        {
            Parser parser = new Parser();
            bool ArrayExpression = parser.TryParse(input, out output);
            Assert.False(ArrayExpression);
        }
        [TestCase("2*2", new string[] { "2", "*", "2" })]
        public void TryParse_IncorrectlyExpression_ReturnTrue(string input, string[] output)
        {
            Parser parser = new Parser();
            bool ArrayExpression = parser.TryParse(input, out output);
            Assert.True(ArrayExpression);
        }
    }
}
