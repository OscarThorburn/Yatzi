using System;
using System.Collections.Generic;

namespace Yatzi
{
    internal class Player
    {
        public string PlayerName { get; set; }
        private string[] DicesToThrowAgainOptions = new string[] { "1", "2", "3", "4", "5" };
        public List<int> PlayerScore = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public List<int> DicesToThrowAgainList = new List<int>();
        public int NumberOfThrows { get; set; }

        private Score score = new Score();

        public Player(string name)
        {
            PlayerName = name;
            NumberOfThrows = 1;
        }

        public int DicesToThrowAgain(int startX = 0, int startY = 10, int optionsPerColumn = 1, int columnSpacing = 3)
        {
            int counter = 1, diceNumber = 1, done = 1;
            ConsoleKey key;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Highlight and press ENTER the dices you want to throw again.\n'T' to throw the dice\n'D' to stop you round");
            while (counter < 6)
            {
                do
                {
                    for (int i = 0; i < DicesToThrowAgainOptions.Length; i++)
                    {
                        Console.SetCursorPosition(i / optionsPerColumn >= 1 ? startX + columnSpacing * (i / optionsPerColumn) : startX, startY + i % optionsPerColumn);
                        if (i + 1 == diceNumber) Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{DicesToThrowAgainOptions[i]}");
                        Console.ResetColor();
                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (diceNumber - 1 >= optionsPerColumn) diceNumber -= optionsPerColumn;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (diceNumber - 1 + optionsPerColumn < DicesToThrowAgainOptions.Length) diceNumber += optionsPerColumn;
                                else if (optionsPerColumn < DicesToThrowAgainOptions.Length) diceNumber = DicesToThrowAgainOptions.Length;
                                break;
                            }
                        case ConsoleKey.T:
                            {
                                diceNumber = -1;
                                break;
                            }
                        case ConsoleKey.D:
                            {
                                diceNumber = -1;
                                done = -2;
                                break;
                            }
                    }
                } while (key != ConsoleKey.Enter && key != ConsoleKey.T && key != ConsoleKey.D);

                if (diceNumber > 0 && !DicesToThrowAgainList.Contains(diceNumber))
                {
                    DicesToThrowAgainList.Add(diceNumber);
                    counter++;
                    Console.WriteLine("\nMarked dices: {0}\r", string.Join(" ", DicesToThrowAgainList));
                }
                else if (diceNumber == -1) { break; }
            }     
            Console.SetCursorPosition(0, 11);
            Console.Write("                                        ");
            return done;
        }

        public void PrintPlayerInfo()
        {
            Console.SetCursorPosition(10, 0);
            Console.Write("                                        \r");
            Console.Write($"{PlayerName} {NumberOfThrows}/3");
        }

        public void PrintPlayerScore()
        {
            for (int i = 0; i < PlayerScore.Count; i++)
            {
                Console.SetCursorPosition(15, i + 15);
                Console.Write(PlayerScore[i] != -1 ? PlayerScore[i].ToString() : "--");
            }
            for (int i = 0; i < score.PlayerScoreCardOptions.Length; i++)
            {
                Console.SetCursorPosition(0, i + 15);
                Console.Write(score.PlayerScoreCardOptions[i]);
            }
        }

        public void ResetDiceList()
        {
            DicesToThrowAgainList.Clear();
        }

        public void CalculatePlayerScore(List<int> diceResult)
        {
            int scoreCardIndex = score.ScoreCardMenu();
            PlayerScore[scoreCardIndex - 1] = (score.CalculateScore(diceResult, scoreCardIndex));
        }
    }
}