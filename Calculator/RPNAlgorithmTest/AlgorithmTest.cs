using NUnit.Framework;
using RPNAlgorithm;

namespace RPNAlgorithmTest
{
    [TestFixture]
    class AlgorithmTest
    {
        string[] test = new string[] { "2", "+", "2", "*", "2" };
        [Test]
        public void DoAlgorithm_CorrectlyResult()
        {
            Algorithm alg = new Algorithm(test);
            double res = alg.Calc();
            Assert.AreEqual(6, res);
        }
    }
}
