using System;
using System.Collections.Generic;

namespace OOP_Battleship
{


    public class Board
    {
        private int rows;
        private int cols;
        public Square[,] ocean;

        public int BoardSize { get; internal set; }

        public Board(int rows = (int)FixedVariables.BoardSize, int cols = (int)FixedVariables.BoardSize)
        {
            this.rows = rows;
            this.cols = cols;
            ocean = new Square[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ocean[i, j] = new Square((i, j));
                    ocean[i, j].SquereStatus = SquareStatus.Empty;

                }
            }
        }

        public void UpdateOcean(int i, int j, SquareStatus status)
        {

            ocean[i, j].SquereStatus = status;
        }
        public void AddPlayertoBoard(Player player)
        {
            foreach (Ship ship in player.Fleet)
            {
                for (int i = 0; i < (int)ship.Type; i++)
                {
                    {
                        if (ship.Elements[i].SquereStatus != SquareStatus.Ship)
                        {
                            ocean[ship.Elements[i].Position.x, ship.Elements[i].Position.y] = ship.Elements[i];
                        }
                    }
                }
            }
        }
        public override string ToString()
        {

            string boardStr = "   " + string.Join(" ", GetColumnLetters()) + "\n";
            for (int i = 0; i < rows; i++)
            {
                string rowStr = string.Join(" ", GetRowSquares(i));
                boardStr += $"{i + 1,2} {rowStr}\n";
            }
            return boardStr;
        }

        private IEnumerable<string> GetColumnLetters()
        {
            for (int i = 0; i < cols; i++)
            {
                yield return ((char)(65 + i)).ToString();
            }
        }

        private IEnumerable<string> GetRowSquares(int row)
        {
            for (int j = 0; j < cols; j++)
            {
                Square s = ocean[row, j];
                yield return s.GetCharacter().ToString();
            }
        }

        public Square GetSquareAtPosition((int x, int y) position)
        {
            return ocean[position.x, position.y];
        }
    }
}