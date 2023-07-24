using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Game
    {
        public Game() 
        {
            
        }

        public void Run()
        {
            while (Battleship.gameActive)
            {
                Console.Clear();
                Console.WriteLine("Enter coordinates (or type 'exit' to quit): ");
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    Battleship.gameActive = false;
                }

            }
        }

    }
}
