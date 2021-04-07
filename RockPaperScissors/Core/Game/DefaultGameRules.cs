using RockPaperScissors.Core.Rules;
using System.Collections.Generic;
namespace RockPaperScissors.Core.Game
{
    public class DefaultGameRules : IRules
    {
        public IEnumerable<Rule> GetRules()
        {
            return new List<Rule>
            {
                new Rule(Rules.RockPaperScissors.Paper, Rules.RockPaperScissors.Paper, RuleResult.Draw),
                new Rule(Rules.RockPaperScissors.Paper, Rules.RockPaperScissors.Rock, new RuleResult(Rules.RockPaperScissors.Paper)),
                new Rule(Rules.RockPaperScissors.Paper, Rules.RockPaperScissors.Scissors, new RuleResult(Rules.RockPaperScissors.Scissors)),
                new Rule(Rules.RockPaperScissors.Rock, Rules.RockPaperScissors.Rock, RuleResult.Draw),
                new Rule(Rules.RockPaperScissors.Rock, Rules.RockPaperScissors.Paper, new RuleResult(Rules.RockPaperScissors.Paper)),
                new Rule(Rules.RockPaperScissors.Rock, Rules.RockPaperScissors.Scissors, new RuleResult(Rules.RockPaperScissors.Rock)),
                new Rule(Rules.RockPaperScissors.Scissors, Rules.RockPaperScissors.Scissors, RuleResult.Draw),
                new Rule(Rules.RockPaperScissors.Scissors, Rules.RockPaperScissors.Paper, new RuleResult(Rules.RockPaperScissors.Scissors)),
                new Rule(Rules.RockPaperScissors.Scissors, Rules.RockPaperScissors.Rock, new RuleResult(Rules.RockPaperScissors.Rock))
            };
        }
    }
}