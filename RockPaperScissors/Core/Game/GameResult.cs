using RockPaperScissors.Core.Player;
namespace RockPaperScissors.Core.Game
{
    public class GameResult
    {
        public GameResult(IPlayer winner, Rules.RockPaperScissors winningChoice)
        {
            _Winner = winner;
            _WinningChoice = winningChoice;
        }
        private GameResult()
        {
            _IsDraw = true;
        }

        private readonly IPlayer _Winner;
        private readonly Rules.RockPaperScissors _WinningChoice;
        private readonly bool _IsDraw;

        public IPlayer Winner { get { return _Winner; } }
        public Rules.RockPaperScissors WinningChoice { get { return _WinningChoice; } }
        public bool IsDraw { get { return _IsDraw; } }

        public static GameResult Draw = new GameResult();
    }
}