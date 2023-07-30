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

                if (currentPlayer == 1)
                {
                    currentBoard = playerOneBoard;
                    Console.WriteLine(currentBoard);
                    (int x, int y) = playerOne.GetShootCoordinates();
                    var effect = playerOne.Shoot(playerTwo, (x, y), currentBoard);

                    Console.Write(effect.ToString());
                    Thread.Sleep(1000);

                    if (playerTwo.IsPlayerDead())
                    {

                        Battleship.gameActive = false;
                        break;
                    }
                    currentPlayer = 2;

                }
                else
                {
                    currentBoard = playerTwoBoard;
                    Console.WriteLine(currentBoard);
                    (int x, int y) = playerTwo.GetShootCoordinates();
                    var effect = playerTwo.Shoot(playerOne, (x, y), currentBoard);

                    Console.Write(effect.ToString());
                    Thread.Sleep(1000);

                    if (playerTwo.IsPlayerDead())
                    {
                        Battleship.gameActive = false;
                        break;
                    }
                    currentPlayer = 1;
                }

            }
            Console.WriteLine();
            Console.WriteLine("----- END OF THE GAME -----");
            Console.WriteLine($"PLAYER {currentPlayer} WON!");
            Thread.Sleep(5000);

        }


    }


}
