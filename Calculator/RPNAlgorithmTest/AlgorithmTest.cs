using NUnit.Framework;
using RPNAlgorithm;

namespace RPNAlgorithmTest
{
    [TestFixture]
    class AlgorithmTest
    {
        [TestCase(new string[] { "2", "2", "+" }, 4)]
        [TestCase(new string[] { "2", "3", "-" }, -1)]
        [TestCase(new string[] { "10", "5", "/" }, 2)]
        [TestCase(new string[] { "2", "3", "*" }, 6)]
        [TestCase(new string[] { "2", "3", "*","2","*" }, 12)]
        public void DoAlgorithm_CorrectlyResult(string[] test,double res)
        {
            Algorithm alg = new Algorithm(test);
            Assert.AreEqual(res, alg.Calc());
        }
    }
}
