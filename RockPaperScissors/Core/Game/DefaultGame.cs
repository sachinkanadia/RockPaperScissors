using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using System;
namespace RockPaperScissors.Core.Game
{
    public class DefaultGame : IGame
    {
        public virtual GameResult Play(IPlayer playerOne, IPlayer playerTwo, IRules gameRules)
        {
            var playerOneChoice = playerOne.Choose();
            OnPlayerOneChoiceMade(playerOneChoice);

            var playerTwoChoice = playerTwo.Choose();
            OnPlayerTwoChoiceMade(playerTwoChoice);

            var rules = gameRules.GetRules();

            foreach (var rule in rules)
            {
                if (rule.IsMatch(playerOneChoice, playerTwoChoice))
                {
                    GameResult result = null;

                    if (rule.Result.IsDraw)
                        result = GameResult.Draw;
                    else if (rule.Result.Winner == playerOneChoice)
                        result = new GameResult(playerOne, playerOneChoice);
                    else if (rule.Result.Winner == playerTwoChoice)
                        result = new GameResult(playerTwo, playerTwoChoice);

                    OnGameComplete(result);
                    return result;
                }
            }

            throw new ApplicationException("Unable to ascertain a winner!");
        }

        protected virtual void OnPlayerOneChoiceMade(Rules.RockPaperScissors choice) { }
        protected virtual void OnPlayerTwoChoiceMade(Rules.RockPaperScissors choice) { }
        protected virtual void OnGameComplete(GameResult result) { }
    }
}