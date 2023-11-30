namespace TriangleUtilities.Tests
{
    public class TriangleTypeCalculatorTests
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        public void CalculateTriangleTypeThrowsArgumentException(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            // arrange
            var calculator = new TriangleTypeCalculator();

            // act & assert
            Assert.Throws<ArgumentException>(() => calculator.CalculateTriangleType(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 1, 1)]
        [InlineData(1, 3, 1)]
        [InlineData(1, 1, 3)]
        public void CalculateTriangleTypeThrowsInvalidTriangleException(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            // arrange
            var calculator = new TriangleTypeCalculator();

            // act & assert
            Assert.Throws<InvalidTriangleException>(() => calculator.CalculateTriangleType(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 3.5)]
        public void CalculateTriangleTypeReturnsAcuteTriangleType(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            // arrange
            var calculator = new TriangleTypeCalculator();

            // act
            var actualType = calculator.CalculateTriangleType(firstSide, secondSide, thirdSide);

            // assert
            Assert.Equal(TriangleType.AcuteTriangle, actualType);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(0.3, 0.4, 0.5)]
        [InlineData(0.5, 1.2, 1.3)]
        public void CalculateTriangleTypeReturnsRightTriangleType(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            // arrange
            var calculator = new TriangleTypeCalculator();

            // act
            var actualType = calculator.CalculateTriangleType(firstSide, secondSide, thirdSide);

            // assert
            Assert.Equal(TriangleType.RightTriangle, actualType);
        }

        [Theory]
        [InlineData(3, 4, 6)]
        [InlineData(1.5, 2, 3)]
        public void CalculateTriangleTypeReturnsObtuseTriangleType(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            // arrange
            var calculator = new TriangleTypeCalculator();

            // act
            var actualType = calculator.CalculateTriangleType(firstSide, secondSide, thirdSide);

            // assert
            Assert.Equal(TriangleType.ObtuseTriangle, actualType);
        }
    }
}