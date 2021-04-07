using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using System;
namespace RockPaperScissors.Core.Session
{
    public class Session
    {
        public Session(IPlayer playerOne, IPlayer playerTwo, IGame game)
        {
            _PlayerOne = playerOne;
            _PlayerTwo = playerTwo;
            _Game = game;
        }

        private readonly IPlayer _PlayerOne;
        private readonly IPlayer _PlayerTwo;
        private readonly IGame _Game;

        public SessionResult Play(IRules rules, int rounds)
        {
            var breakWhenGamesWon = (rounds / 2) + 1;
            var playerOneWins = 0;
            var playerTwoWins = 0;

            for (var i = 0; i < rounds; i++)
            {
                var gameResult = _Game.Play(_PlayerOne, _PlayerTwo, rules);

                if (gameResult.IsDraw)
                    continue;

                if (gameResult.Winner == _PlayerOne)
                    playerOneWins++;
                else
                    playerTwoWins++;

                if (playerOneWins == breakWhenGamesWon || playerTwoWins == breakWhenGamesWon)
                    break;
            }

            if (playerOneWins == playerTwoWins)
                return SessionResult.Draw;
            if (playerOneWins > playerTwoWins)
                return new SessionResult(_PlayerOne);
            if (playerTwoWins > playerOneWins)
                return new SessionResult(_PlayerTwo);

            throw new ApplicationException("Unable to ascertain a winner!");
        }
    }
}