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
        private Display displayManager = new Display();
        private Input inputManager = new Input();
        private int userChoice;
        internal static bool gameActive = true;

        public Battleship()
        {
            while (gameActive)
            {
                if (userChoice == 1)
                {
                    StartGame();
                }
                else if (userChoice == 2)
                {
                    DisplayHighScore();
                }
                else if (userChoice == 3)
                {
                    gameActive = false;
                }
                else
                {
                    DisplayMainMenu();
                }
            }
            ExitGame();
        }

        private void DisplayMainMenu()
        {
            displayManager.PrintMenu();
            userChoice = inputManager.GetDigitInput();   
        }

        private void StartGame()
        {
            Game game = new Game();
            game.Run();
        }

        private void DisplayHighScore()
        {
            displayManager.HighScore();
            userChoice = inputManager.GetDigitInput();
        }

        private void ExitGame()
        {
            displayManager.EndGame();
        }
    }
}
