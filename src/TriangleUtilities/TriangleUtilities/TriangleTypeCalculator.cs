using Ardalis.GuardClauses;

namespace TriangleUtilities
{
    /// <summary>
    /// Represents a triangle type calculator
    /// </summary>
    public class TriangleTypeCalculator : ITriangleTypeCalculator
    {
        /// <summary>
        /// Calculates a type of triangle by its sides(Acute, Obtuse or Right)
        /// </summary>
        /// <param name="firstSide">First side, positive</param>
        /// <param name="secondSide">Second side, positive</param>
        /// <param name="thirdSide">Third side, positive</param>
        /// <returns>Type of triangle (Acute, Obtuse or Right)</returns>
        /// <remarks>If one side is bigger or equal than sum of others, then the triangle considered as invalid</remarks>
        public TriangleType CalculateTriangleType(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            Guard.Against.NegativeOrZero(firstSide);
            Guard.Against.NegativeOrZero(secondSide);
            Guard.Against.NegativeOrZero(thirdSide);

            if (!IsTriangleValid(firstSide, secondSide, thirdSide))
            {
                throw new InvalidTriangleException();
            }

            var firstSqr = firstSide * firstSide;
            var secondSqr = secondSide * secondSide;
            var thirdSqr = thirdSide * thirdSide;

            if (firstSqr == secondSqr + thirdSqr
                || secondSqr == firstSqr + thirdSqr
                || thirdSqr == firstSqr + secondSqr)
            {
                return TriangleType.RightTriangle;
            }
            else if (firstSqr > secondSqr + thirdSqr
                || secondSqr > firstSqr + thirdSqr
                || thirdSqr > firstSqr + secondSqr)
            {
                return TriangleType.ObtuseTriangle;
            }

            return TriangleType.AcuteTriangle;
        }

        private bool IsTriangleValid(decimal firstSide, decimal secondSide, decimal thirdSide)
        {
            return firstSide < secondSide + thirdSide
                && secondSide < firstSide + thirdSide
                && thirdSide < firstSide + secondSide;
        }
    }
}
