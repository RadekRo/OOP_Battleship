using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Game
    {
        private Board playerOneBoard = new Board();
        private Board playerTwoBoard = new Board();

        public Game() 
        {
            
        }

        public void Run()
        {
            while (Battleship.gameActive)
            {
                Console.Clear();
                Console.WriteLine("Enter coordinates (or type 'exit' to quit): ");
                Console.WriteLine(playerOneBoard);
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    Battleship.gameActive = false;
                }

            }
        }

    }
}
