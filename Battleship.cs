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
        private int userChoice;
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
                if (userChoice == 0) 
                {
                    gameActive = false;
                }
            }
        } 

        private void DisplayMainMenu()
        {
            display.PrintMenu();
            userChoice = input.GetDigitInput();
        }

        private void StartGame()
        {

        }

        private void DisplayHighScore()
        {

        }

        public void ExitGame()
        {

        }
    }
}
