using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Yatzi
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice(6);
            Console.WriteLine("Welcom to Yatzi. Please enter player names...");
            Player playerOne = new Player(Console.ReadLine());
            Player playerTwo = new Player(Console.ReadLine());
            Console.Clear();
            
            for (int gameRound = 1; gameRound < 15; gameRound++)
            {
                dice.ThrowAllDice();
                dice.PrintDiceResult();
                playerOne.PrintPlayerInfo();
                playerOne.PrintPlayerScore();

                for (int playerThrows = 1; playerThrows < 3; playerThrows++)
                {
                    playerOne.NumberOfThrows++;                  
                    if (playerOne.DicesToThrowAgain() == -2)
                    {
                        break;
                    }
                    dice.ThrowDice(playerOne.DicesToThrowAgainList);
                    playerOne.ResetDiceList();
                    dice.PrintDiceResult();
                    playerOne.PrintPlayerInfo();

                }
                playerOne.CalculatePlayerScore(dice.diceResult);
                
                Console.Clear();

                dice.ThrowAllDice();
                dice.PrintDiceResult();
                playerTwo.PrintPlayerInfo();
                playerTwo.PrintPlayerScore();

                for (int playerThrows = 1; playerThrows < 3; playerThrows++)
                {
                    playerTwo.NumberOfThrows++;
                    if (playerTwo.DicesToThrowAgain() == -2)
                    {
                        break;
                    }
                    dice.ThrowDice(playerTwo.DicesToThrowAgainList);
                    playerTwo.ResetDiceList();
                    dice.PrintDiceResult();
                    playerTwo.PrintPlayerInfo();
                }
                playerTwo.CalculatePlayerScore(dice.diceResult);
                Console.Clear();

                playerOne.NumberOfThrows = playerTwo.NumberOfThrows = 1;
            }

            Console.Clear();
            Console.WriteLine($"{playerOne.PlayerName}: {playerOne.PlayerScore.Sum()}\n {playerTwo.PlayerName}: {playerTwo.PlayerScore.Sum()}");
            Console.Write(playerOne.PlayerScore.Sum() > playerTwo.PlayerScore.Sum() ? $"Grattis {playerOne.PlayerName}" : $"Grattis {playerTwo.PlayerName}");
            Console.ReadKey();
        }
    }
}
