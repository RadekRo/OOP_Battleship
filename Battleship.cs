using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Battleship
    {

        private Display display = new Display();
        private Input input = new Input();
        private int userInput;
        public bool gameActive = true;

        public Battleship()
        {
            Run();
        }
        private void Run()
        {
            while (gameActive)
            {
                DisplayMainMenu();
                if (userInput == 2) 
                {
                    ExitGame();
                }
            }
        } 

        private void DisplayMainMenu()
        {
            display.PrintMenu();
            Console.Write("Enter your choice: ");
            userInput = input.GetDigitInput();
            
        }

        private void StartGame()
        {

        }

        private void DisplayHighScore()
        {

        }

        public void ExitGame()
        {
            Console.WriteLine("You have decided to exit the game...");
            Console.WriteLine("Thank you for playing Battleship!");
            gameActive = false;
        }
    }
}
