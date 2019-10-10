using NUnit.Framework;
using lab_12_test_me_out;
using just_do_it_11_rabbit_explosion;
//using lab_just_Do_It_enum_With_Tests;

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

        [TestCase(1, 2, "Monday", "February")]
        [TestCase(2, 2, "Monday", "February")]
        public void TestGetDayMonth(int day, int month, string expectedDay, string expectedMonth)
        {
            var actual = TestEnums.GetDayMonth(day, month);
            Assert.AreEqual(expectedDay, actual.Item1);
            Assert.AreEqual(expectedMonth, actual.Item2);
        }
    }
}