using Moq;
using NUnit.Framework;
using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using RockPaperScissors.Core.Session;
namespace RockPaperScissors.Test
{
    public class SessionTests
    {
        [SetUp]
        public void Setup()
        { }

        private readonly IRules _Rules = new DefaultGameRules();

        [Test]
        public void TestBestOfThreeWinner()
        {
            var rounds = 3;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Scissors)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Scissors);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.AreSame(playerTwo.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(rounds));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(rounds));
        }

        [Test]
        public void TestBestOfFiveExitOnThreeRounds()
        {
            var rounds = 5;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(3));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(3));
        }

        [Test]
        public void TestBestOfNineExitOnFiveRounds()
        {
            var rounds = 9;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(5));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(5));
        }

        [Test]
        public void TestBestOfTenExitOnSixRounds()
        {
            var rounds = 10;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(6));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(6));
        }

        [Test]
        public void TestBestOfFourDraw()
        {
            var rounds = 4;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.IsNull(result.Winner);
            Assert.IsTrue(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(rounds));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(rounds));
        }

        [Test]
        public void TestBestOfTenDraw()
        {
            var rounds = 10;

            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock);

            playerTwo.SetupSequence(p => p.Choose())
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Rock)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper)
                .Returns(Core.Rules.RockPaperScissors.Paper);

            var session = new Session(new DefaultGame());
            var result = session.Play(playerOne.Object, playerTwo.Object, _Rules, rounds);

            Assert.IsNull(result.Winner);
            Assert.IsTrue(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Exactly(rounds));
            playerTwo.Verify(p => p.Choose(), Times.Exactly(rounds));
        }
    }
}