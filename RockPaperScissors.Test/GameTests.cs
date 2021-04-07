using Moq;
using NUnit.Framework;
using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Rules;
using System;
using System.Collections.Generic;
namespace RockPaperScissors.Test
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        { }

        private readonly IRules _Rules = new DefaultGameRules();

        [Test]
        public void TestPlayerTwoRockWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerTwo.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPlayerTwoPaperWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerTwo.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPlayerTwoScissorsWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerTwo.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPlayerOneRockWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPlayerOnePaperWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPlayerOneScissorsWins()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.AreSame(playerOne.Object, result.Winner);
            Assert.IsFalse(result.IsDraw);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestRockDraw()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Rock);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.IsTrue(result.IsDraw);         
            Assert.IsNull(result.Winner);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestPaperDraw()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Paper);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.IsTrue(result.IsDraw);
            Assert.IsNull(result.Winner);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestScissorDraw()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();

            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);

            var game = new DefaultGame();
            var result = game.Play(playerOne.Object, playerTwo.Object, _Rules);

            Assert.IsTrue(result.IsDraw);
            Assert.IsNull(result.Winner);
            playerOne.Verify(p => p.Choose(), Times.Once);
            playerTwo.Verify(p => p.Choose(), Times.Once);
        }

        [Test]
        public void TestApplicationExceptionThrown()
        {
            var playerOne = new Mock<IPlayer>();
            var playerTwo = new Mock<IPlayer>();
            var rules = new Mock<IRules>();

            rules.Setup((r) => r.GetRules()).Returns(new List<Rule>());
            playerOne.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);
            playerTwo.Setup(p => p.Choose()).Returns(Core.Rules.RockPaperScissors.Scissors);

            var game = new DefaultGame();

            var exception = Assert.Throws<ApplicationException>(() => { game.Play(playerOne.Object, playerTwo.Object, rules.Object); });
            Assert.AreEqual("Unable to ascertain a winner!", exception.Message);
        }
    }
}