using System;
namespace RockPaperScissors.Core.Player
{
    public class ComputerPlayer : IPlayer
    {
        private readonly Random _Random = new Random();

        public Rules.RockPaperScissors Choose()
        {
            var randomValue = _Random.Next(1, 4);
            var value = (Rules.RockPaperScissors)randomValue;
            return value;
        }
    }
}