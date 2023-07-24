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
                if (userInput == 2)
                {
                    DisplayHighScore();
                }

                else if (userInput == 3) 
                {
                    ExitGame();
                }
                else
                {
                    DisplayMainMenu();
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
            Console.Clear();
            Console.WriteLine("------- High Score -------");
            Console.WriteLine("1. Henry 200 pts");
            Console.WriteLine("2. George 200 pts");
            Console.WriteLine("3. Mary 200 pts");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Press '0' to return to Main Menu...");
            userInput = input.GetDigitInput();
        }

        public void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("You have decided to exit the game...");
            Console.WriteLine("Thank you for playing Battleship!");
            gameActive = false;
        }
    }
}
