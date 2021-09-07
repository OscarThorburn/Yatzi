using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzi
{
    class Player
    {
        private int Score { get; set; }
        private string PlayerName { get; set; }
        public List<int> diceNumberList = new List<int>();

        public int numberOfThrows = 1;


        public Player(string name)
        {
            PlayerName = name;
        }

        public void DicesToThrowAgain()
        {
            string userInput = string.Empty;
            int counter = 1, diceNumber;            
            Console.WriteLine("Which dices do you want to throw 1-5. Type a number and then hit 'ENTER', when finnished type 'DONE'");
            while (counter < 6)
            {               
                userInput = Console.ReadLine().ToUpper().Trim();
                if(int.TryParse(userInput, out diceNumber))
                {
                    diceNumberList.Add(diceNumber);
                    counter++;
                }
                else if(userInput == "DONE")
                {
                   break;
                }
                else
                {
                    Console.WriteLine("Felaktigt format");
                } 
            }
        }

        public void PrintPlayerInfo()
        {
            Console.SetCursorPosition(10, 0);
            Console.Write($"{PlayerName} {numberOfThrows}/3");

        }
            


}
}
