using OOP_Battleship;

public class Display
{
    public void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("----- Game menu -----");
        Console.WriteLine("1. Start a New Game");
        Console.WriteLine("2. Display Highscores");
        Console.WriteLine("3. Exit");
        Console.WriteLine("---------------------");
        Console.Write("Enter your choice: ");
    }

    //public void PrintBoard(char[,] board)
    //{
    //    int rows = board.GetLength(0);
    //    int cols = board.GetLength(1);

    //    Console.WriteLine("----- Plansza -----");
    //    for (int row = 0; row < rows; row++)
    //    {
    //        for (int col = 0; col < cols; col++)
    //        {
    //            Console.Write(board[row, col] + " ");
    //        }
    //        Console.WriteLine();
    //    }
    //    Console.WriteLine("--------------------");
    //}
    
    public void PrintBoard(Board board)
    {
        Console.WriteLine(board);
    }

    public void PrintGameplay()
    {
        Console.WriteLine("----- Rozgrywka -----");
        // Wypisanie aktualnego stanu rozgrywki
        Console.WriteLine("---------------------");
    }

    public void AskForUserCoordinates()
    {
        Console.Write("Enter starting ship coordinates (for ex. A1): ");
    }

    public void InvalidChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("");
        Console.WriteLine("WRONG ENTRY! Use only avaliable menu option numbers!");
        Console.ResetColor();
    }

    public void InvalidCoordinate()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("WRONG COORDINATES!! Try again");
        Console.ResetColor();
    }

    public void PrintGameOver(bool isPlayerWin)
    {
        Console.WriteLine("----- Koniec gry -----");
        if (isPlayerWin)
        {
            Console.WriteLine("Gratulacje! Wygrałeś!");
        }
        else
        {
            Console.WriteLine("Niestety, przegrałeś. Spróbuj jeszcze raz!");
        }
        Console.WriteLine("-----------------------");
    }

    public void HighScore()
    {
        Console.Clear();
        Console.WriteLine("------- High Score -------");
        Console.WriteLine("1. Henry 200 pts");
        Console.WriteLine("2. George 200 pts");
        Console.WriteLine("3. Mary 200 pts");
        Console.WriteLine("--------------------------");
        Console.WriteLine("Press '0' to return to Main Menu...");
    }

    public void EndGame()
    {
        Console.Clear();
        Console.WriteLine("You have decided to exit the game...");
        Console.WriteLine("Thank you for playing Battleship!");
    }
}