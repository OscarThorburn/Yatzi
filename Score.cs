using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzi
{
    class Score
    {

        private string[] PlayerScoreCardOptions = new string[] { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor", "Par", "Två-Par", "Tre-Par", "Fyr-Par", "Liten Stege", "Stor Stege", "Kåk", "Chans", "Yatzi" };
        public int ScoreCardMenu(int startX = 0, int startY = 15, int optionsPerColumn = 15)
        {
            int currentSelection = 1;
            Console.CursorVisible = false;
            ConsoleKey key;

            do
            {
                for (int i = 0; i < PlayerScoreCardOptions.Length; i++)
                {
                    Console.SetCursorPosition(i / optionsPerColumn >= 1 ? startX * (i / optionsPerColumn) : startX, startY + i % optionsPerColumn);

                    if (i + 1 == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{PlayerScoreCardOptions[i]}: ");

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection - 1 % optionsPerColumn > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection % optionsPerColumn <= optionsPerColumn && currentSelection < PlayerScoreCardOptions.Length)
                                currentSelection++;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            return currentSelection;
        }
    }
}
