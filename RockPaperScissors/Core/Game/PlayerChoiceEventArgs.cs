using System;
namespace RockPaperScissors.Core.Game
{
    public class PlayerChoiceEventArgs : EventArgs
    {
        public PlayerChoiceEventArgs(Rules.RockPaperScissors playerChoice)
        {
            _PlayerChoice = playerChoice;
        }

        private readonly Rules.RockPaperScissors _PlayerChoice;

        public Rules.RockPaperScissors PlayerChoice
        {
            get
            {
                return _PlayerChoice;
            }
        }
    }
}
