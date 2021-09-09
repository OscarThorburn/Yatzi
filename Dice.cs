using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzi
{
    class Dice
    {
        public int Sides { get; set; }
        public int[] diceResult = new int[5];
        

        public Dice(int sides)
        {
            Sides = sides;
        }

        private void ThrowDice(int diceNumber)
        {
            Random rnd = new Random();
            diceResult[diceNumber - 1] = rnd.Next(1, Sides + 1);
        }

        public void ThrowAllDice()
        {
            for (int i = 1; i < 6; i++)
            {
                ThrowDice(i);
            }
        }

        public void ThrowDice(List<int> diceNumberList)
        {
            foreach (var number in diceNumberList)
            {
                ThrowDice(number);
            }
        }
        public void PrintDiceResult()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player:\n" +
                $"_____________________\n" +
                $"|   |   |   |   |   | \n" +
                $"| {diceResult[0]} | {diceResult[1]} | {diceResult[2]} | {diceResult[3]} | {diceResult[4]} |\n" +
                $"|___|___|___|___|___| ");
        }
    }
}
