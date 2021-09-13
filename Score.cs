using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzi
{
    class Score
    {

        public string[] PlayerScoreCardOptions = new string[] { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor", "Par", "Tre-Par", "Fyr-Par", "Liten Stege", "Stor Stege", "Kåk", "Chans", "Yatzi" };
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

                    if (i + 1 == currentSelection) Console.ForegroundColor = ConsoleColor.Green;
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

        public int CalculateScore(List<int> diceResult, int scoreCardIndex)
        {
            int score = 0;

            if (1 <= scoreCardIndex && scoreCardIndex <= 6)
            {
                switch (scoreCardIndex)
                {
                    case 1:
                        score = diceResult.Where(diceValue => diceValue == 1).Sum();
                        break;
                    case 2:
                        score = diceResult.Where(diceValue => diceValue == 2).Sum();
                        break;
                    case 3:
                        score = diceResult.Where(diceValue => diceValue == 3).Sum();
                        break;
                    case 4:
                        score = diceResult.Where(diceValue => diceValue == 4).Sum();
                        break;
                    case 5:
                        score = diceResult.Where(diceValue => diceValue == 5).Sum();
                        break;
                    case 6:
                        score = diceResult.Where(diceValue => diceValue == 6).Sum();
                        break;
                }
            }
            else if(7 <= scoreCardIndex && scoreCardIndex <= 10)
            {
                bool multipleOfTheSameKind = false;
                switch (scoreCardIndex)
                {
                    case 7: //Par
                        for (int diceValue = 6; diceValue >= 1; diceValue--)
                        {
                            int counter = 0;
                            for (int diceNumber = 0; diceNumber < 5; diceNumber++)
                            {
                                if (diceResult[diceNumber] == diceValue) counter++;
                                if (counter == 2) { score = diceValue * 2; multipleOfTheSameKind = true; }

                            }
                            if (multipleOfTheSameKind == true) break;
                        }
                        break; 
                    case 8:  //Triss                      
                        for (int diceValue = 1; diceValue <= 6; diceValue++)
                        {
                            int counter = 0;
                            for (int diceNumber = 0; diceNumber < 5; diceNumber++)
                            {
                                if (diceResult[diceNumber] == diceValue) counter++;
                                if (counter == 3) { score = diceValue * 3; multipleOfTheSameKind = true; }

                            }
                            if (multipleOfTheSameKind == true) break;
                        }
                        break;
                    case 9: //Fyr-par
                        for (int diceValue = 1; diceValue <= 6; diceValue++)
                        {
                            int counter = 0;
                            for (int diceNumber = 0; diceNumber < 5; diceNumber++)
                            {
                                if (diceResult[diceNumber] == diceValue) counter++;
                                if (counter == 4) { score = diceValue * 4; multipleOfTheSameKind = true; }

                            }
                            if (multipleOfTheSameKind == true) break;
                        }
                        break;
                }
            }
            else
            {
                switch (scoreCardIndex)
                {
                    
                    case 10: //liten stege
                        List<int> litenStege = new List<int> { 1, 2, 3, 4, 5 };
                        score = diceResult.OrderBy(diceValue => diceValue).SequenceEqual(litenStege) ? 15 : 0;
                        break;
                    case 11: //Stor stege
                        List<int> storStege = new List<int> { 2, 3, 4, 5, 6 };
                        score = diceResult.OrderBy(diceValue => diceValue).SequenceEqual(storStege) ? 20 : 0;
                        break;                    
                    case 12: //kåk
                        var tempList = diceResult.OrderBy(value => value).ToList();
                        if (tempList[0] == tempList[1] && tempList[0] == tempList[2] && tempList[4] == tempList[3]) { score = (tempList[0] * 3) + (tempList[4] * 2); }
                        else if (tempList[2] == tempList[3] && tempList[3] == tempList[4] && tempList[0] == tempList[1]) { score = (tempList[0] * 2) + (tempList[4] * 3); }
                        break;
                    case 13: //Chans
                        score = diceResult.Sum();
                        break;                   
                    case 14: //Yatzi!
                        score = diceResult.Any(diceValue => diceValue != diceResult[0]) ? 0 : 50;
                        break;
                }
            }
            return score;
        }
    }
}

