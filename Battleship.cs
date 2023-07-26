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
        private Game gameManager = new Game();
        private int userChoice;
        internal static bool gameActive = true;

        public Battleship()
        {
            while (gameActive)
            {
                DisplayMainMenu();
                
                switch (userChoice)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        DisplayHighScore();
                        break;
                    case 3:
                        gameActive = false;
                        break;
                    default:
                        displayManager.InvalidChoice();
                        Thread.Sleep(1000);
                        break;
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
            gameManager.Run();
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
