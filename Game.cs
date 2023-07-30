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
                Console.Clear();
                Console.WriteLine($"Player {currentPlayer} shooting phase");
                if (currentPlayer == 1)
                {
                    Console.WriteLine(playerOneBoard);
                    (int x, int y) = playerOne.GetShootCoordinates();
                    var effect = playerOne.Shoot(playerTwo, (x, y));
                    switch (effect.ToString())
                    {
                        case "Hit":
                            playerOneBoard.ocean[x, y] = new Square((x, y), SquareStatus.Hit);
                            break;
                        case "Sunk":
                            playerOneBoard.ocean[x, y] = new Square((x, y), SquareStatus.Sink);
                            break;
                        default:
                            playerOneBoard.ocean[x, y] = new Square((x, y), SquareStatus.Miss);
                            break;
                    }
                    Console.Write(effect.ToString());
                    Thread.Sleep(1000);
                    currentPlayer = 2;               }
                else
                {
                    Console.WriteLine(playerTwoBoard);
                    (int x, int y) = playerTwo.GetShootCoordinates();
                    var effect = playerTwo.Shoot(playerOne, (x, y));
                    switch (effect.ToString())
                    {
                        case "Hit":
                            playerTwoBoard.ocean[x, y] = new Square((x, y), SquareStatus.Hit);
                            break;
                        case "Sunk":
                            playerTwoBoard.ocean[x, y] = new Square((x, y), SquareStatus.Sink);
                            break;
                        default:
                            playerTwoBoard.ocean[x, y] = new Square((x, y), SquareStatus.Miss);
                            break;
                    }
                    Console.Write(effect.ToString());
                    Thread.Sleep(1000);
                    currentPlayer = 1;
                }

            }
        }

    }
}
