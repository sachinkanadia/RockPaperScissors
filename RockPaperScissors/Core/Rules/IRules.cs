using System.Collections.Generic;
namespace RockPaperScissors.Core.Rules
{
    public interface IRules
    {
        IEnumerable<Rule> GetRules();
    }
}