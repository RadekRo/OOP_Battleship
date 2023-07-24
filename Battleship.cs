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
        private int digitInput;
        public bool gameActive = true;

        public Battleship()
        {
            digitInput = input.GetDigitInput();
            Console.WriteLine(digitInput);
            display.PrintMenu();
            Run();
        }
        public void Run()
        {
            while (gameActive)
            {
                digitInput = input.GetDigitInput();
                Console.WriteLine(digitInput);
                if (digitInput == 0) 
                {
                    gameActive = false;
                }
            }
        } 

        public void DisplayMainMenu()
        {

        }

        public void StartGame()
        {

        }

        public void DisplayHighScore()
        {

        }

        public void ExitGame()
        {

        }
    }
}
