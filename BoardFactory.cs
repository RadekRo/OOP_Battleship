using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class BoardFactory
    {
        private Display displayManager = new Display();
        private Input inputManager = new Input();


        // ---------



        private bool CanPlaceShip(Board board, Ship ship, (int x, int y) coordinates)
        {

            int size = ship.Elements.Count;

            if (ship.IsVertical)
            {
                // if (y + size > BoardSize) return false
            }

            else
            {
                // if (y + size > BoardSize) return false
            }

            var initialPos = ship.Elements[0].Position;

            if (board.GetSquareAtPosition(initialPos).SquerStatus != SquareStatus.Empty) return false;

            for (int i = 0; i < size; i++)
            {
                int posX = ship.IsVertical ? initialPos.x : initialPos.x + i;
                int posY = ship.IsVertical ? initialPos.y = initialPos.y + i : initialPos.y;

                if (board.GetSquareAtPosition((posX, posY)).SquerStatus != SquareStatus.Empty) return false;

            }

            return true;

        }
        // public bool RandomPlacement(Board board, Ship ship, (int x, int y) coordinates)
        // {
        //  if (!CanPlaceShip(board, ship, coordinates))
        //  {
        //     return false;
        //  }

        // lista wolnych coordinates
        // wybierz dowolny koordynat z listy
        // jak nie mozna położyć statku to usuwasz koordynat z listy
        // jak mozesz, to kladziesz
        //  done


        // return true;

        // }
        public bool RandomPlacement(Board board, Ship ship, (int x, int y) coordinates)
        {
            List<(int x, int y)> freeCoordinates = new List<(int x, int y)>();


            for (int x = 0; x < board.BoardSize; x++)
            {
                for (int y = 0; y < board.BoardSize; y++)
                {
                    if (board.GetSquareAtPosition((x, y)).SquerStatus == SquareStatus.Empty)
                    {
                        freeCoordinates.Add((x, y));
                    }
                }
            }

            int size = ship.Elements.Count;
            bool placed = false;

            while (freeCoordinates.Count > 0 && !placed)
            {
                int randomIndex = new Random().Next(0, freeCoordinates.Count);
                var randomCoordinate = freeCoordinates[randomIndex];
                freeCoordinates.RemoveAt(randomIndex);

                if (CanPlaceShip(board, ship, randomCoordinate))
                {
                    CanPlaceShip(board, ship, randomCoordinate);
                    placed = true;
                }
            }

            return placed;
        }
        public void ManualPlacement(Board board, Player player)
        {

            foreach (ShipTypes shipType in Enum.GetValues(typeof(ShipTypes)))
            {

                int shipSize = (int)shipType;
                bool validCoordinate = false;

                while (!validCoordinate)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Player {player.Name}. Deploy your fleet!");
                    Console.ResetColor();
                    Console.WriteLine("------------------------------");
                    displayManager.PrintBoard(board);
                    Console.WriteLine($"Placing {shipType} (size {shipSize})");
                    displayManager.AskForUserCoordinates();
                    string shipCoordinates = inputManager.GetStringInput();

                    if (!inputManager.ValidateStringInput(shipCoordinates) ||
                        !inputManager.ValidateCoordinates(shipCoordinates))
                    {
                        displayManager.InvalidCoordinate();
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        (int x, int y) = inputManager.TranslateCoordinates(shipCoordinates);
                        board.ocean[x, y].SquerStatus = SquareStatus.Ship;
                        List<Square> shipElements = new List<Square>();
                        shipElements.Add(board.ocean[x, y]);
                        Console.WriteLine("Horizontal or Vertical [h/v]: ");
                        string orientationInput = inputManager.GetStringInput().ToUpper();
                        while (orientationInput != "H" && orientationInput != "V")
                        {
                            Console.WriteLine("Wrong Input");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("Horizontal or Vertical [h/v]: ");
                            orientationInput = inputManager.GetStringInput();
                        }
                        bool isVertical = true;
                        int count = shipSize - 1;
                        switch (orientationInput)
                        {
                            case "H":
                                isVertical = false;
                                if (y + shipSize - 1 < 10)
                                {
                                    while (count > 0)
                                    {
                                        board.ocean[x, y + count].SquerStatus = SquareStatus.Ship;
                                        shipElements.Add(board.ocean[x, y + count]);
                                        count--;

                                    }
                                }
                                else
                                {
                                    while (count > 0)
                                    {
                                        board.ocean[x, y - count].SquerStatus = SquareStatus.Ship;
                                        shipElements.Add(board.ocean[x, y - count]);
                                        count--;

                                    }

                                }

                                break;
                            case "V":
                                isVertical = true;
                                if (x + shipSize - 1 < 10)
                                {
                                    while (count > 0)
                                    {
                                        board.ocean[x + count, y].SquerStatus = SquareStatus.Ship;
                                        shipElements.Add(board.ocean[x + count, y]);
                                        count--;

                                    }
                                }
                                else
                                {
                                    while (count > 0)
                                    {
                                        board.ocean[x - count, y].SquerStatus = SquareStatus.Ship;
                                        shipElements.Add(board.ocean[x - count, y]);
                                        count--;

                                    }

                                }

                                break;
                        }

                        Ship ship = new Ship(shipElements, shipType);
                        ship.IsVertical = isVertical;
                        player.Fleet.Add(ship);
                        shipElements.Clear();
                        validCoordinate = true;
                    }

                }
                //board.ocean[0, i].SquerStatus = SquareStatus.ship;
            }
        }
    }
}
