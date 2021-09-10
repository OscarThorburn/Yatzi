using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

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
            
            for (int gameRound = 1; gameRound < 14; gameRound++)
            {
                dice.ThrowAllDice();
                dice.PrintDiceResult();
                playerOne.PrintPlayerInfo();

                for (int playerThrows = 1; playerThrows < 3; playerThrows++)
                {
                    playerOne.NumberOfThrows++;
                    playerOne.DicesToThrowAgain();
                    dice.ThrowDice(playerOne.DicesToThrowAgainList);
                    playerOne.ResetDiceList();
                    dice.PrintDiceResult();
                    playerOne.PrintPlayerInfo();
                    playerOne.CalculateScore(dice.diceResult);
                }

                dice.ThrowAllDice();
                dice.PrintDiceResult();
                playerTwo.PrintPlayerInfo();

                for (int playerThrows = 1; playerThrows < 3; playerThrows++)
                {
                    playerTwo.NumberOfThrows++;
                    playerTwo.DicesToThrowAgain();
                    dice.ThrowDice(playerTwo.DicesToThrowAgainList);
                    playerTwo.ResetDiceList();
                    dice.PrintDiceResult();
                    playerTwo.PrintPlayerInfo();
                }

                playerOne.NumberOfThrows = playerTwo.NumberOfThrows = 1;
            }
        }
    }
}
