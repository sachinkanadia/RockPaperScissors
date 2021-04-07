namespace RockPaperScissors.Core.Rules
{
    public class RuleResult
    {
        public RuleResult(RockPaperScissors winner)
        {
            _Winner = winner;
        }
        private RuleResult()
        {
            _IsDraw = true;
        }

        private readonly RockPaperScissors _Winner;
        private readonly bool _IsDraw;

        public RockPaperScissors Winner { get { return _Winner; } }
        public bool IsDraw { get { return _IsDraw; } }

        public static RuleResult Draw = new RuleResult();
    }
}