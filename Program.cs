using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Yatzi
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1);
            Dice dice = new Dice(6);
            Player playerOne = new Player("Filip");
            Player playerTwo = new Player("Kalle");

            dice.ThrowAllDice();
            dice.PrintDiceResult();
            playerOne.PrintPlayerInfo();
            for (int gameRound = 1; gameRound < 14; gameRound++)
            {
                for (int playerThrows = 1; playerThrows < 3; playerThrows++)
                {
                    playerOne.numberOfThrows++;
                    Console.SetCursorPosition(0, 8);
                    playerOne.DicesToThrowAgain();
                    dice.ThrowDices(playerOne.diceNumberList);
                    dice.PrintDiceResult();

                   

                }
                dice.PrintDiceResult();
                for (int playerThrows = 0; playerThrows < 3; playerThrows++)
                {

                }
            }


        }
    }
}
