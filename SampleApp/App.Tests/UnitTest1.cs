using NUnit.Framework;

namespace App.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSumMethod()
        {
            MathBL bl = new MathBL();
            Assert.IsTrue(bl.Sum(2, 3) == 5);
        }
    }

    public class MathBL
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}