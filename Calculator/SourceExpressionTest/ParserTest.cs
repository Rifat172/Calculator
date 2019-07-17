using NUnit.Framework;
using SourceExpression;

namespace SourceExpressionTest
{
    [TestFixture]
    class ParserTest
    {
        [Test]
        public void Parse_SimpleGoodExpression_GoodArray()
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse("2*2+2");
            Assert.AreEqual(new string[] { "2", "*", "2", "+", "2" }, ArrayExpression);
        }
        [Test]
        public void Parse_SimpleGoodExpression_BadArray()
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse("2+2*2");
            Assert.AreNotEqual(new string[] { "2", "*", "2", "+", "2" }, ArrayExpression);
        }
        [TestCase("(2.5+0.5)*2",new string[] { "(","2.5","+","0.5",")","*","2"})]
        public void Parse_CorrectlyExpression_CorrectlyArray(string input, string[] output)
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse(input);
            Assert.AreEqual(output, ArrayExpression);
        }
        
        [Test]
        public void Parse_DifficultGoodExpression_GoodArray()
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse("(22+2)*2");
            Assert.AreEqual(new string[] { "(", "22", "+", "2", ")", "*", "2" }, ArrayExpression);
        }
    }
}
