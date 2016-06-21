using FizzBuzzGame;
using NUnit.Framework;

namespace FizzBuzzTest
{
    [TestFixture]
    public class SampleGameTest
    {
        private Game _game;
        private string[] _expectedAnswers;

        public SampleGameTest()
        {
            _expectedAnswers = new[]
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "Fizz Buzz"
            };
        }

        [Test]
        public void GameExecutionTest()
        {
            const int gameLength = 15;
            var answers = new string[gameLength];

            _game = new Game( gameLength );
            _game.Start();

            for (var i = 0; i < gameLength; i++)
            {
                answers[i] = _game.NextTurn();
            }

            VerifyAnswers( answers );
        }

        private void VerifyAnswers( string[] answers )
        {
            for (var i = 0; i < answers.Length; i++)
            {
                Assert.AreEqual( _expectedAnswers[i], answers[i] );
            }
        }
    }
}
