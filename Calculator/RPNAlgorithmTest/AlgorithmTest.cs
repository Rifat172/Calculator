using NUnit.Framework;
using RPNAlgorithm;

namespace RPNAlgorithmTest
{
    [TestFixture]
    class AlgorithmTest
    {
        [TestCase(new string[] { "2", "2", "+" }, 4)]
        [TestCase(new string[] { "2", "3", "+" }, 5)]
        public void DoAlgorithm_CorrectlyResult(string[] test,double res)
        {
            Algorithm alg = new Algorithm(test);
            Assert.AreEqual(res, alg.Calc());
        }
    }
}
