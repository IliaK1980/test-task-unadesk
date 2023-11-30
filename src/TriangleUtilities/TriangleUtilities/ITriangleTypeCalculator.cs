namespace TriangleUtilities
{
    /// <summary>
    /// Represents an interface for triangle type calculator
    /// </summary>
    public interface ITriangleTypeCalculator
    {
        /// <summary>
        /// Calculates a type of triangle by its sides(Acute, Obtuse or Right)
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side</param>
        /// <param name="thirdSide">Third side</param>
        /// <returns>Type of triangle (Acute, Obtuse or Right)</returns>
        /// <remarks>If one side is bigger or equal than sum of others, then the triangle considered as invalid</remarks>
        TriangleType CalculateTriangleType(decimal firstSide, decimal secondSide, decimal thirdSide);
    }
}