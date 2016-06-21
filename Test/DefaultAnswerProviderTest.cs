using FizzBuzzGame;
using NUnit.Framework;

namespace FizzBuzzTest
{
    [TestFixture]
    public class DefaultAnswerProviderTest
    {
        private DefaultAnswerProvider _answerProvider;

        public DefaultAnswerProviderTest()
        {
            _answerProvider = new DefaultAnswerProvider();
        }

        [TestCase( 1 )]
        [TestCase( 2 )]
        [TestCase( 4 )]
        [TestCase( 8 )]
        [TestCase( 11 )]
        public void ReturnsStringRepresentationOfGivenNumber( int number )
        {
            var answer = _answerProvider.GetAnswer( number );

            Assert.AreEqual( number.ToString(), answer );
        }

        [TestCase( 3 )]
        [TestCase( 6 )]
        [TestCase( 9 )]
        [TestCase( 12 )]
        public void ReturnsKeywordForNumbersDividableBy3( int number )
        {
            var keyword = DefaultAnswerProvider.DividableBy3Keyword;

            var answer = _answerProvider.GetAnswer( number );

            Assert.AreEqual( keyword, answer );
        }

        [TestCase( 5 )]
        [TestCase( 10 )]
        [TestCase( 20 )]
        [TestCase( 25 )]
        public void ReturnsKeywordForNumbersDividableBy5( int number )
        {
            var keyword = DefaultAnswerProvider.DividableBy5Keyword;

            var answer = _answerProvider.GetAnswer( number );

            Assert.AreEqual( keyword, answer );
        }

        [TestCase( 15 )]
        [TestCase( 30 )]
        [TestCase( 45 )]
        public void ReturnsBothKeywordsForNumbersDividableBothBy3And5( int number )
        {
            var keyword = DefaultAnswerProvider.DividableBy3And5Keyword;

            var answer = _answerProvider.GetAnswer( number );

            Assert.AreEqual( keyword, answer );
        }
    }
}
