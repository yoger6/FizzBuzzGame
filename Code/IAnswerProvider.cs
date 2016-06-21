namespace FizzBuzzGame
{
    /// <summary>
    /// Supplies game with text answers to match the game requests
    /// </summary>
    public interface IAnswerProvider
    {
        /// <summary>
        /// Provides answer
        /// </summary>
        /// <param name="number">Number that answer is requested for</param>
        /// <returns>Answer to given number</returns>
        string GetAnswer( int number );
    }
}