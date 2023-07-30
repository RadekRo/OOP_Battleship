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
        private int currentPlayer;
        public Board currentBoard;


        public Game()
        {
            boardFactory = new BoardFactory();
            playerOne = new Player();
            playerTwo = new Player();
            playerOneBoard = new Board();
            playerTwoBoard = new Board();
            playerOne.PlayerNumber = 1;
            playerTwo.PlayerNumber = 2;
            currentPlayer = playerOne.PlayerNumber;
        }

        public void Run()
        {
            boardFactory.ManualPlacement(playerOneBoard, playerOne);
            boardFactory.ManualPlacement(playerTwoBoard, playerTwo);
            playerOneBoard = new Board();

            playerTwoBoard = new Board();

            currentBoard = playerOneBoard;

            while (Battleship.gameActive)
            {
                playerOneBoard.AddPlayertoBoard(playerTwo);

                playerTwoBoard.AddPlayertoBoard(playerOne);
                Console.Clear();
                Console.WriteLine($"Player {currentPlayer} shooting phase");
                Console.WriteLine(currentBoard);
                //Console.WriteLine(playerOne.IsPlayerDead());
                if (currentPlayer == 1)
                {

                    var input = playerOne.GetShootCoordinates();

                    Console.WriteLine(playerOne.Shoot(playerTwo, input, currentBoard));

                    //Console.WriteLine(input);
                    //Console.ReadLine();
                    currentPlayer = 2;
                    currentBoard = playerTwoBoard;
                }
                else
                {
                    var input = playerTwo.GetShootCoordinates();
                    //Console.WriteLine(input);
                    //Console.ReadLine();
                    currentPlayer = 1;
                    currentBoard = playerOneBoard;
                }
            }
        }

    }
}
