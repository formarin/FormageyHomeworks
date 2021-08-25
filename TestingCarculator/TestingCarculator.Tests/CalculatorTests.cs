using Xunit;

namespace TestingCarculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void GetSum_2_Plus_2_Eq_4()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.GetSum(2, 2);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void GetSubstract_4_Minus_2_Eq_2()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.GetSubstract(4, 2);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetMultiplication_2_Mult_2_Eq_4()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.GetMultiplication(2, 2);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void GetDivision_4_Divide_2_Eq_2()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.GetDivision(4, 2);

            //Assert
            Assert.Equal(2, result);
        }
    }
}
