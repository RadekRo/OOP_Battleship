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

    public void PrintBoard(char[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        Console.WriteLine("----- Plansza -----");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------");
    }

    public void PrintGameplay()
    {
        Console.WriteLine("----- Rozgrywka -----");
        // Wypisanie aktualnego stanu rozgrywki
        Console.WriteLine("---------------------");
    }

    public void InvalidChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("");
        Console.WriteLine("WRONG ENTRY! Use only avaliable menu option numbers!");
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

public class Game
{
    // Inne składowe klasy Game

    //static void Main(string[] args)
    //{
    //    Display display = new Display();
    //    display.PrintMenu();

    //    // Tutaj można dodać logikę obsługi wyboru w menu gry
    //    // np. wywołanie funkcji odpowiedzialnej za rozpoczęcie nowej gry

    //    // Przykład użycia metody PrintBoard:
    //    char[,] playerBoard = new char[,]
    //    {
    //        { '-', '-', '-', '-', '-', '-', '-', '-' },
    //        { '-', '-', '-', '-', '-', '-', '-', '-' },
    //        { '-', '-', '-', 'S', 'S', 'S', '-', '-' },
    //        { '-', '-', '-', '-', '-', '-', '-', '-' },
    //        { '-', 'C', 'C', 'C', 'C', '-', '-', '-' },
    //        { '-', '-', '-', '-', '-', '-', '-', '-' },
    //        { '-', '-', '-', '-', '-', '-', '-', '-' },
    //        { '-', '-', '-', '-', '-', '-', '-', '-' }
    //    };

    //    display.PrintBoard(playerBoard);

    //    // Przykład użycia metody PrintGameplay:
    //    display.PrintGameplay();

    //    // Przykład użycia metody PrintGameOver:
    //    bool isPlayerWin = true;
    //    display.PrintGameOver(isPlayerWin);
    //}
}