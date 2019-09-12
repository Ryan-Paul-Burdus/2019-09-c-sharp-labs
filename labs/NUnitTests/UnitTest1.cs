using NUnit.Framework;
using lab_12_test_me_out;
using just_do_it_11_rabbit_explosion;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var expected = 100;
            var actual = TestMeSomething.RunThisNow(10);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 100)]
        [TestCase(100, 10000)]
        [TestCase(9, 81)]
        public void Test1(int input, int expected)
        {
            var actual = TestMeSomething.RunThisNow(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 8)]
        public void TestRabbitExplosion(int populationLimit, int expectedYears)
        {
            //arrange


            //act
            var actualYears = just_do_it_11_rabbit_exp.Rabbit_Exponential_Growth(populationLimit);

            //assert
            Assert.AreEqual(expectedYears, actualYears);
        }
    }
}