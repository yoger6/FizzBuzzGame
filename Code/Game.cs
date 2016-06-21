using System;

namespace FizzBuzzGame
{
    /// <summary>
    /// Core of the Fizz Buzz game controling its flow.
    /// </summary>
    public class Game
    {
        private readonly IAnswerProvider _answerProvider;

        /// <summary>
        /// Determines if the game already started
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Current turn of the game
        /// </summary>
        public int CurrentTurn { get; private set; }

        /// <summary>
        /// Number of turn at which the game will end.
        /// </summary>
        public int LastTurnNumber { get; }

        /// <summary>
        /// Default constructor of the Game
        /// </summary>
        /// <param name="playTurns">Number of turns the game will last</param>
        public Game(int playTurns = 100)
            :this(new DefaultAnswerProvider(), playTurns)
        {
        }

        /// <summary>
        /// Constructor allowing to inject custom IAnswerProvider
        /// </summary>
        /// <param name="answerProvider">Provides answers for each turn</param>
        /// <param name="playTurns">Number of turns the game will last</param>
        public Game( IAnswerProvider answerProvider, int playTurns = 100 )
        {
            _answerProvider = answerProvider;
            if (playTurns < 1)
            {
                throw new ArgumentException("Cannot play game shorter than one turn.");
            }
            LastTurnNumber = playTurns;
        }

        /// <summary>
        /// Starts the game and resets turns
        /// </summary>
        public void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException( "Game is already running." );
            }
            
            IsRunning = true;
            CurrentTurn = 0;
        }

        /// <summary>
        /// Steps into next turn of the game,  ends the game if the turn is the last one
        /// </summary>
        /// <returns>Answer for next turn</returns>
        public string NextTurn()
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException( "Start game before calling next turn." );
            }
            CurrentTurn++;
            if (IsLastTurn())
            {
                EndGame();
            }

            return _answerProvider.GetAnswer( CurrentTurn );
        }

        private bool IsLastTurn()
        {
            return CurrentTurn == LastTurnNumber;
        }

        private void EndGame()
        {
            IsRunning = false;
        }
    }
}
