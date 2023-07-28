using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Game
    {
        private BoardFactory boardFactory;
        private Board playerOneBoard;
        private Board playerTwoBoard;
        private Player playerOne;
        private Player playerTwo;

        public Game()
        {
            boardFactory = new BoardFactory();
            playerOne = new Player();
            playerTwo = new Player();
            playerOneBoard = new Board();
            playerTwoBoard = new Board();
        }

        public void Run()
        {
            boardFactory.ManualPlacement(playerOneBoard, "One", playerOne);
            boardFactory.ManualPlacement(playerTwoBoard, "Two", playerTwo);
            while (Battleship.gameActive)
            {
                Console.Clear();
                Console.WriteLine("And now, something completely different...");
                Console.ReadLine();
                Battleship.gameActive = false;
            }
        }

    }
}
