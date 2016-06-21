namespace FizzBuzzGame
{
    /// <summary>
    /// Provides answers for default Fizz Buzz game where
    /// numbers that can be divided without remainder
    /// by 3 or 5; or 3 and 5 have their answer replaced with 
    /// specified keywords. Otherwise their string representation 
    /// is returned;
    /// </summary>
    public class DefaultAnswerProvider : IAnswerProvider
    {
        public const string DividableBy3Keyword = "Fizz";
        public const string DividableBy5Keyword = "Buzz";
        public const string DividableBy3And5Keyword = DividableBy3Keyword +" "+ DividableBy5Keyword;

        /// <summary>
        /// Provides answer
        /// </summary>
        /// <param name="number">Number that answer is requested for</param>
        /// <returns>Answer to given number</returns>
        public string GetAnswer( int number )
        {
            if (IsDividableBy3And5( number ))
            {
                return DividableBy3And5Keyword;
            }
            else if (IsDividableBy3( number ))
            {
                return DividableBy3Keyword;
            }
            else if (IsDividableBy5( number ))
            {
                return DividableBy5Keyword;
            }

            return number.ToString();
        }


        private bool IsDividableBy3And5( int number )
        {
            return IsDividableBy3( number ) && IsDividableBy5( number );
        }

        private bool IsDividableBy3( int number )
        {
            return IsDividableWithoutRemainder( number, 3 );
        }

        private bool IsDividableBy5( int number )
        {
            return IsDividableWithoutRemainder( number, 5 );
        }

        private bool IsDividableWithoutRemainder( int dividend, int divisor )
        {
            return dividend%divisor == 0;
        }
    }
}