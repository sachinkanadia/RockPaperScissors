namespace RockPaperScissors.Core.Rules
{
    public class Rule
    {
        public Rule(RockPaperScissors valueOne, RockPaperScissors valueTwo, RuleResult result)
        {
            _ValueOne = valueOne;
            _ValueTwo = valueTwo;
            _Result = result;
        }

        private readonly RockPaperScissors _ValueOne;
        private readonly RockPaperScissors _ValueTwo;
        private readonly RuleResult _Result;
        
        public RuleResult Result
        {
            get { return _Result; }
        }

        public bool IsMatch(RockPaperScissors valueOne, RockPaperScissors valueTwo)
        {
            return valueOne == _ValueOne && valueTwo == _ValueTwo;
        }
    }
}