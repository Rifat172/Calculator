using NUnit.Framework;
using RPNAlgorithm;

namespace RPNAlgorithmTest
{
    [TestFixture]
    class ConvertTest
    {
        [TestCase(new string[] { "3", "+", "2" }, new string[] { "3", "2", "+"})]
        [TestCase(new string[] { "3", "-", "2" }, new string[] { "3", "2", "-"})]
        [TestCase(new string[] { "(", "3", "-","2",")","*","5","+","10,1" }, new string[] { "3", "2", "-","5","*","10,1","+"})]
        public void StaticToRPN_CorrectlyInput_CorrectlyOutPut(string[] InPut, string[] ExcpectedOutPut)
        {
            string[] RPNExpression = Convert.ToRPN(InPut);
            Assert.AreEqual(ExcpectedOutPut, RPNExpression);
        }
    }
}