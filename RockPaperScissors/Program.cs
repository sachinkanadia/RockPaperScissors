using RockPaperScissors.Core.Game;
using RockPaperScissors.Core.Player;
using RockPaperScissors.Core.Session;
using System;
namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var invalidInputString = "Invalid input!";

            Console.WriteLine("Rock Paper Scissors");

            IPlayer playerOne = null;
            IPlayer playerTwo = null;

            var makeHumanChoice = new Func<HumanPlayer, Core.Rules.RockPaperScissors>(
                (player) =>
                {
                    while (true)
                    {
                        var playerString = player == playerOne ? "Player One" : "Player Two";

                        Console.WriteLine("Please select either rock, paper or scissors for {0}, press 'R' for Rock, 'P' for Paper or 'S' for Scissors", playerString);
                        var key = Console.ReadKey();
                        Console.WriteLine();
                        if (key.Key == ConsoleKey.R)
                        {
                            return Core.Rules.RockPaperScissors.Rock;
                        }
                        else if (key.Key == ConsoleKey.P)
                        {
                            return Core.Rules.RockPaperScissors.Paper;
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            return Core.Rules.RockPaperScissors.Scissors;
                        }
                        else
                        {
                            Console.WriteLine(invalidInputString);
                        }
                    }
                }
            );

            while (true)
            {
                try
                {
                    while (playerOne == null)
                    {
                        Console.WriteLine("Please select the first player type, press 'C' for Computer or 'H' for Human");
                        var key = Console.ReadKey();
                        Console.WriteLine();
                        if (key.Key == ConsoleKey.C)
                        {
                            playerOne = new ComputerPlayer();
                        }
                        else if (key.Key == ConsoleKey.H)
                        {
                            playerOne = new HumanPlayer(makeHumanChoice);
                        }
                        else
                        {
                            Console.WriteLine(invalidInputString);
                        }
                    }

                    while (playerTwo == null)
                    {
                        Console.WriteLine("Please select the second player type, press 'C' for Computer or 'H' for Human");
                        var key = Console.ReadKey();
                        Console.WriteLine();
                        if (key.Key == ConsoleKey.C)
                        {
                            playerTwo = new ComputerPlayer();
                        }
                        else if (key.Key == ConsoleKey.H)
                        {
                            playerTwo = new HumanPlayer(makeHumanChoice);
                        }
                        else
                        {
                            Console.WriteLine(invalidInputString);
                        }
                    }

                    var game = new NotificationEnabledGame();
                    game.PlayerOneChoice += (sender, args) => { Console.WriteLine("Player One Choice Entered: {0}", Enum.GetName(typeof(Core.Rules.RockPaperScissors), args.PlayerChoice)); };
                    game.PlayerTwoChoice += (sender, args) => { Console.WriteLine("Player Two Choice Entered: {0}", Enum.GetName(typeof(Core.Rules.RockPaperScissors), args.PlayerChoice)); };
                    game.GameResult += (sender, args) =>
                    {
                        if (args.Result.IsDraw)
                        {
                            Console.WriteLine("Game result: Draw");
                            return;
                        }

                        var winnerString = (args.Result.Winner == playerOne) ? "Player One" : "Player Two";
                        var winningChoiceString = Enum.GetName(typeof(Core.Rules.RockPaperScissors), args.Result.WinningChoice);

                        Console.WriteLine("Game result: Winner {0}, Winning Choice {1}", winnerString, winningChoiceString);
                    };

                    var session = new Session(playerOne, playerTwo, game);
                    var result = session.Play(new DefaultGameRules(), 3);

                    if (result.IsDraw)
                    {
                        Console.WriteLine("Session ended in a Draw");
                    }
                    else
                    {
                        Console.WriteLine("Winner of Session is: {0}", result.Winner == playerOne ? "Player One" : "Player Two");
                    }

                    Console.WriteLine("To play again press 'Y', to exit press any other key.");
                    var playAgainKey = Console.ReadKey();
                    Console.WriteLine();
                    if (playAgainKey.Key != ConsoleKey.Y)
                        break;
                }
                finally
                {
                    playerOne = null;
                    playerTwo = null;
                }
            }
        }
    }
}