using NUnit.Framework;
using Hospital.Domain;

namespace Tests
{
    [TestFixture]
    public class Tests  // Delete this and the class "CalculatorSimple"
    {
        [SetUp]
        public void Setup()
        {
            //Nothing for now
        }

        [Test]
        public void MustAdditionTwoNumbers()
        {
            CalculatorSimple calculatorSimple = new CalculatorSimple();

            int result = calculatorSimple.Addition(1, 3);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void MustMultiplyTwoNumbers()
        {
            CalculatorSimple calculatorSimple = new CalculatorSimple();

            int result = calculatorSimple.Multiplication(1, 3);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}