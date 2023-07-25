using System;
using System.Collections.Generic;

public enum ShipType
{
    Carrier,
    Battleship,
    Cruiser,
    Submarine,
    Destroyer
}

public enum Orientation
{
    Horizontal,
    Vertical
}

public class Square
{
    public bool IsOccupied { get; set; } 
    public ShipType ShipType { get; set; } 
}

public class Board
{
    private int rows;
    private int cols; 
    public Square[,] ocean; 

    public Board(int rows = 10, int cols = 10)
    {
        this.rows = rows;
        this.cols = cols;
        ocean = new Square[rows, cols]; 
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                ocean[i, j] = new Square();
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
            yield return ocean[row, j].ToString(); 
        }
    }
}