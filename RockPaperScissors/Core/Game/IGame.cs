using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using System;
namespace RockPaperScissors.Core.Game
{
    public interface IGame
    {
        GameResult Play(IPlayer playerOne, IPlayer playerTwo, IRules gameRules);
    }
}