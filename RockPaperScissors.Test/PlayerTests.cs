using NUnit.Framework;
using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
namespace RockPaperScissors.Test
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        { }

        private readonly IRules _Rules = new DefaultGameRules();

        [Test]
        public void TestSimulateComputerVsComputerGame()
        {
            var playerOne = new ComputerPlayer();
            var playerTwo = new ComputerPlayer();
            var game = new DefaultGame();
            game.Play(playerOne, playerTwo, _Rules);
        }

        [Test]
        public void TestSimulateComputerVsHumanGame()
        {
            var playerOne = new ComputerPlayer();
            var playerTwo = new HumanPlayer((p) => Core.Rules.RockPaperScissors.Scissors);
            var game = new DefaultGame();
            game.Play(playerOne, playerTwo, _Rules);
        }

        [Test]
        public void TestSimulateHumanVsHumanGame()
        {
            var playerOne = new HumanPlayer((p) => Core.Rules.RockPaperScissors.Paper);
            var playerTwo = new HumanPlayer((p) => Core.Rules.RockPaperScissors.Scissors);
            var game = new DefaultGame();
            var result = game.Play(playerOne, playerTwo, _Rules);

            Assert.AreSame(playerTwo, result.Winner);
            Assert.IsFalse(result.IsDraw);
        }
    }
}