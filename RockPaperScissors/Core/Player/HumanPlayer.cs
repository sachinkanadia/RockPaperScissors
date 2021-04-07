using System;
namespace RockPaperScissors.Core.Player
{
    public class HumanPlayer : IPlayer
    {
        public HumanPlayer(Func<HumanPlayer, Rules.RockPaperScissors> makeChoice)
        {
            _MakeChoice = makeChoice;
        }

        private Func<HumanPlayer, Rules.RockPaperScissors> _MakeChoice;

        public Rules.RockPaperScissors Choose()
        {
            return _MakeChoice(this);
        }
    }
}