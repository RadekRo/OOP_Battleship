﻿using System;
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
        internal static bool gameActive = true;

        public Battleship()
        {
            Start();
        }
        private void Start()
        {
            while (gameActive)
            {
                if (userInput == 1)
                {
                    StartGame(); 
                }
                
                else if (userInput == 2)
                {
                    DisplayHighScore();
                }

                else if (userInput == 3) 
                {
                    break;
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
            display.PrintMenu();
            userInput = input.GetDigitInput();
            
        }

        private void StartGame()
        {
            Game game = new Game();
            game.Run();
        }

        private void DisplayHighScore()
        {
            display.HighScore();
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
