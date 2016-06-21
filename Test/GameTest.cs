using System;
using FizzBuzzGame;
using Moq;
using NUnit.Framework;

namespace FizzBuzzTest
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;
        private Mock<IAnswerProvider> _answerProviderMock;

        [SetUp]
        public void Setup()
        {
            _answerProviderMock = new Mock<IAnswerProvider>();
            _game = new Game(_answerProviderMock.Object, 1);
        }

        [Test]
        public void StartBeginsTheGame()
        {
            _game.Start();

            Assert.True( _game.IsRunning );
        }

        [Test]
        public void DefaultGameLasts100Turns()
        {
            var defaultGame = new Game();

            Assert.AreEqual( 100, defaultGame.LastTurnNumber );
        }

        [Test]
        public void GameLengthCanBeSetInConstructor()
        {
            var dissapointinglyShortGame = new Game( 2 );

            Assert.AreEqual( 2, dissapointinglyShortGame.LastTurnNumber );
        }

        [TestCase( 0 )]
        [TestCase( -1 )]
        public void GameCannotLastLessThan1Turn(int gameLength)
        {
            TestDelegate corruptedGame = () => new Game( gameLength );

            Assert.Throws<ArgumentException>( corruptedGame );
        }

        [Test]
        public void GameCannotStartWhenItsRunning()
        {
            TestDelegate startGame = () => _game.Start();
            
            _game.Start();

            Assert.Throws<InvalidOperationException>( startGame );
        }

        [Test]
        public void GameTurnIs0WhenStarted()
        {
            _game.Start();
            Assert.AreEqual( 0, _game.CurrentTurn );
        }

        [Test]
        public void NextTurnWillThrowIfGameIsntRunning()
        {
            TestDelegate nextTurn = () => _game.NextTurn();

            Assert.Throws<InvalidOperationException>( nextTurn );
        }

        [Test]
        public void NextTurnIncreasesCurrentTurnBy1()
        {
            _game.Start();

            _game.NextTurn();

            Assert.AreEqual( 1, _game.CurrentTurn );
        }

        [Test]
        public void CallingLastTurnEndsGame()
        {
            _game.Start();

            _game.NextTurn();
            
            Assert.False( _game.IsRunning );
        }

        [Test]
        public void NextTurnReturnsAnswerForCurrentTurn()
        {
            _answerProviderMock.Setup( x => x.GetAnswer( 1 ) ).Returns( "1" );
            _game.Start();

            var firstAnswer = _game.NextTurn();

            Assert.AreEqual( "1", firstAnswer );
        }
    }   
}
