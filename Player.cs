using System;
using System.Collections.Generic;

namespace Yatzi
{
    internal class Player
    {
        private string PlayerName { get; set; }
        private string[] DiceMenuOptions = new string[] { "1", "2", "3", "4", "5" };
        private int[] PlayerScore = new int[14];

        public  List<int> diceNumberList = new List<int>();
        public int numberOfThrows = 1;

        public Player(string name)
        {
            PlayerName = name;
        }

        public void DicesToThrowAgain(int startX = 0, int startY = 10, int optionsPerColumn = 1, int columnSpacing = 3, bool enumerate = true)
        {
            int counter = 1, diceNumber = 1;
            ConsoleKey key;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Highlight and press ENTER the dices you want to throw again.\nT to throw the dice!\nD to stop you round");
            while (counter < 6)
            {
                do
                {
                    for (int i = 0; i < DiceMenuOptions.Length; i++)
                    {
                        Console.SetCursorPosition(i / optionsPerColumn >= 1 ? startX + columnSpacing * (i / optionsPerColumn) : startX, startY + i % optionsPerColumn);
                        if (i + 1 == diceNumber) { Console.ForegroundColor = ConsoleColor.Red; }
                        Console.Write(enumerate ? $"{DiceMenuOptions[i]}" : DiceMenuOptions[i]);
                        Console.ResetColor();
                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (diceNumber - 1 >= optionsPerColumn) { diceNumber -= optionsPerColumn; }
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (diceNumber - 1 + optionsPerColumn < DiceMenuOptions.Length) { diceNumber += optionsPerColumn; }
                                else if (optionsPerColumn < DiceMenuOptions.Length) { diceNumber = DiceMenuOptions.Length; }
                                break;
                            }
                        case ConsoleKey.T:
                            {
                                diceNumber = -1;
                                break;
                            }
                    }
                } while (key != ConsoleKey.Enter && key != ConsoleKey.T && key != ConsoleKey.D);

                if (diceNumber != -1 && !diceNumberList.Contains(diceNumber))
                {
                    diceNumberList.Add(diceNumber);
                    counter++;
                    Console.WriteLine("\nMarked dices: {0}\r", string.Join(" ", diceNumberList));
                }
                else if (diceNumber == -1) { break; }
            }
            Console.SetCursorPosition(0, 11);
            Console.Write("                                        ");
        }
        public void PrintPlayerInfo()
        {
            Console.SetCursorPosition(10, 0);
            Console.Write("                                        \r");
            Console.Write($"{PlayerName} {numberOfThrows}/3");
           
        }
        public void ResetDiceList()
        {
            diceNumberList.Clear();
        }

        private void PrintPlayerScores()
        {
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("SCORE CARD");
            for (int i = 0; i < PlayerScore.Length; i++)
            {
                Console.WriteLine("__________");

            }
        }
    }
}