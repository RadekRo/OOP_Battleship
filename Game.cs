﻿using System;
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
            while (Battleship.gameActive)
            {
                boardFactory.ManualPlacement(playerOneBoard, "One");
                boardFactory.ManualPlacement(playerTwoBoard, "Two");
            }
        }

    }
}
