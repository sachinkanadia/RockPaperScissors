using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using System;
namespace RockPaperScissors.Core.Session
{
    public class Session : ISession
    {
        public Session(IGame game)
        {
            _Game = game;
        }

        private readonly IGame _Game;

        public virtual SessionResult Play(IPlayer playerOne, IPlayer playerTwo, IRules rules, int rounds)
        {
            var breakWhenGamesWon = (rounds / 2) + 1;
            var playerOneWins = 0;
            var playerTwoWins = 0;

            for (var i = 0; i < rounds; i++)
            {
                var gameResult = _Game.Play(playerOne, playerTwo, rules);

                if (gameResult.IsDraw)
                    continue;

                if (gameResult.Winner == playerOne)
                    playerOneWins++;
                else
                    playerTwoWins++;

                if (playerOneWins == breakWhenGamesWon || playerTwoWins == breakWhenGamesWon)
                    break;
            }

            if (playerOneWins == playerTwoWins)
                return SessionResult.Draw;
            if (playerOneWins > playerTwoWins)
                return new SessionResult(playerOne);
            if (playerTwoWins > playerOneWins)
                return new SessionResult(playerTwo);

            throw new ApplicationException("Unable to ascertain a winner!");
        }
    }
}