using RockPaperScissors.Core.Player;
namespace RockPaperScissors.Core.Session
{
    public class SessionResult
    {
        public SessionResult(IPlayer winner)
        {
            _Winner = winner;
        }
        private SessionResult()
        {
            _IsDraw = true;
        }

        private readonly IPlayer _Winner;
        private readonly bool _IsDraw;

        public IPlayer Winner { get { return _Winner; } }
        public bool IsDraw { get { return _IsDraw; } }

        public static SessionResult Draw = new SessionResult();
    }
}
