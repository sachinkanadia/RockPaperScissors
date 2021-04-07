using System;
namespace RockPaperScissors.Core.Game
{
    public class NotificationEnabledGame : DefaultGame
    {
        public event EventHandler<PlayerChoiceEventArgs> PlayerOneChoice;
        public event EventHandler<PlayerChoiceEventArgs> PlayerTwoChoice;
        public event EventHandler<GameResultEventArgs> GameResult;

        protected override void OnPlayerOneChoiceMade(Rules.RockPaperScissors choice)
        {
            base.OnPlayerOneChoiceMade(choice);
            PlayerOneChoice?.Invoke(this, new PlayerChoiceEventArgs(choice));
        }
        protected override void OnPlayerTwoChoiceMade(Rules.RockPaperScissors choice)
        {
            base.OnPlayerTwoChoiceMade(choice);
            PlayerTwoChoice?.Invoke(this, new PlayerChoiceEventArgs(choice));
        }
        protected override void OnGameComplete(GameResult result)
        {
            base.OnGameComplete(result);
            GameResult?.Invoke(this, new GameResultEventArgs(result));
        }
    }
}