using NUnit.Framework;
using RPNAlgorithm;

namespace RPNAlgorithmTest
{
    [TestFixture]
    class AlgorithmTest
    {
        [Test]
        public void DoAlgorithm_CorrectlyResult()
        {
            Algorithm alg = new Algorithm(new string[] { "2", "+", "2", "*", "2" });
            double res = alg.Calc();
            Assert.AreEqual(6, res);
        }
        [Test]
        public void DoAlgorithm_AnotherCorrectlyExpression_CorrectlyResult()
        {
            Algorithm alg = new Algorithm(new string[] { "(", "2", "+", "2", ")", "*", "2" });
            double res = alg.Calc();
            Assert.AreEqual(8, res);
        }
    }
}
