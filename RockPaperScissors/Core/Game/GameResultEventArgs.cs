using System;
namespace RockPaperScissors.Core.Game
{
    public class GameResultEventArgs : EventArgs
    {
        public GameResultEventArgs(GameResult result)
        {
            Result = result;
        }

        public GameResult Result { get; private set; }
    }
}