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
        
        [Test]
        public void Parse_DifficultGoodExpression_GoodArray()
        {
            Parser parser = new Parser();
            string[] ArrayExpression = parser.Parse("(22+2)*2");
            Assert.AreEqual(new string[] { "(", "22", "+", "2", ")", "*", "2" }, ArrayExpression);
        }
    }
}
