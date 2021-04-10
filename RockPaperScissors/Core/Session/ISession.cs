using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
namespace RockPaperScissors.Core.Session
{
    public interface ISession 
    {
        SessionResult Play(IPlayer playerOne, IPlayer playerTwo, IRules rules, int rounds);
    }
}