using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        public void FizzBuzz_GetOutput_WhenCorrect(int number, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(14, "FizzBuzz")]
        [TestCase(7, "Fizz")]
        [TestCase(2, "Buzz")]
        public void FizzBuzz_GetOutput_WhenInorrect(int number, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);
            Assert.That(result, Is.Not.EqualTo(expectedResult));
        }
    }
}
