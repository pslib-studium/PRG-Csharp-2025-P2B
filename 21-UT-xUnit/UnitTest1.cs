using _21_UT_Calculator;

namespace _21_UT_xUnit
{
    public class UnitTest1
    {
        private Calculator calculator;
        public UnitTest1()
        {

            calculator = new Calculator();
        }


        [Fact]
        public void TestAdd1and1()
        {
            Calculator calculator = new Calculator();
            double val = calculator.Addition(1, 1);

            Assert.Equal(2, val);

        }

        [Fact]
        public void TestAdition()
        {

            Assert.Equal(10, calculator.Addition(5, 5));
            Assert.Equal(0, calculator.Addition(10, -10));
            Assert.Equal(-5, calculator.Addition(-2, -3));

        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 2, 6)]
        [InlineData(-4, -4, 16)]
        [InlineData(-1, 8, -8)]
        public void TestMul(double a, double b, double expected)
        {
            Assert.Equal(expected, calculator.Multiplication(a, b));
        }

        [Fact]
        public void TestDivide()
        {


            Assert.Equal(2, calculator.Divide(4, 2));
            Assert.Throws<ArgumentException>(() => calculator.Divide(2, 0));


        }
    }
}