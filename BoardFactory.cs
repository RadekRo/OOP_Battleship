using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
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
                if (coordinates.y + size > 10) return false;
            }

            else
            {
                if (coordinates.y - size < 1) return false;
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

            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (board.GetSquareAtPosition((i, j)).SquareStatus == SquareStatus.Empty)
                    {
                        freeCoordinates.Add((i, j));
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
                    PlaceShipOnBoard(board, randomCoordinate, size, RandomOrientation(), ship.Elements);
                    placed = true;
                }
            }

            return placed;
        }

        private string RandomOrientation()
        {
            var orientations = new List<string> { "H", "V" };
            int randomIndex = new Random().Next(0, orientations.Count);
            return orientations[randomIndex];
        }

        private void PrintDeployShipMenu(Board board, Player player, ShipTypes shipType)
        {
            int shipSize = (int)shipType;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player {player.PlayerNumber}. Deploy your fleet!");
            Console.ResetColor();
            Console.WriteLine("------------------------------");
            displayManager.PrintBoard(board);
            Console.WriteLine($"Placing {shipType} (size {shipSize})");
            displayManager.AskForUserCoordinates();

        }
        private string AskForShipOrientation()
        {
            Console.WriteLine("Horizontal or Vertical [h/v]: ");
            string orientationInput = inputManager.GetStringInput().ToUpper();

            while (orientationInput != "H" && orientationInput != "V")
            {
                Console.WriteLine("upss podaj ponownie");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Horizontal or Vertical [h/v]: ");
                orientationInput = inputManager.GetStringInput().ToUpper();
            }

            return orientationInput;
        }


        private bool PlaceShipOnBoard(Board board, (int x, int y) startCoordinates, int shipSize, string orientationInput, List<Square> shipElements)
        {
            board.ocean[startCoordinates.x, startCoordinates.y].SquerStatus = SquareStatus.Ship;

            shipElements.Add(board.ocean[startCoordinates.x, startCoordinates.y]);
            bool isVertical = true;
            int count = shipSize - 1;
            switch (orientationInput)
            {
                case "H":
                    isVertical = false;
                    PutShipHorizontaly(startCoordinates, shipSize, count, board, shipElements);
                    break;
                case "V":
                    isVertical = true;
                    PutShipVerticaly(startCoordinates, shipSize, count, board, shipElements);

                    break;
            }
            return isVertical;
        }

        public void PutShipHorizontaly((int x, int y) startCoordinates, int shipSize, int count, Board board, List<Square> shipElements)
        {
            if (startCoordinates.y + shipSize - 1 < (int)FixedVariables.MaxShipSize)
            {
                while (count > 0)
                {
                    board.ocean[startCoordinates.x, startCoordinates.y + count].SquerStatus = SquareStatus.Ship;
                    shipElements.Add(board.ocean[startCoordinates.x, startCoordinates.y + count]);
                    count--;

                }
            }
            else
            {
                while (count > 0)
                {
                    board.ocean[startCoordinates.x, startCoordinates.y - count].SquerStatus = SquareStatus.Ship;
                    shipElements.Add(board.ocean[startCoordinates.x, startCoordinates.y - count]);
                    count--;

                }

            }
        }

        private void PutShipVerticaly((int x, int y) startCoordinates, int shipSize, int count, Board board, List<Square> shipElements)
        {

            if (startCoordinates.x + shipSize - 1 < (int)FixedVariables.MaxShipSize)
            {
                while (count > 0)
                {
                    board.ocean[startCoordinates.x + count, startCoordinates.y].SquerStatus = SquareStatus.Ship;
                    shipElements.Add(board.ocean[startCoordinates.x + count, startCoordinates.y]);
                    count--;

                }
            }
            else
            {
                while (count > 0)
                {

                    board.ocean[startCoordinates.x - count, startCoordinates.y].SquerStatus = SquareStatus.Ship;
                    shipElements.Add(board.ocean[startCoordinates.x - count, startCoordinates.y]);
                    count--;

                }

            }
        }
        public void ManualPlacement(Board board, Player player)
        {

            foreach (ShipTypes shipType in Enum.GetValues(typeof(ShipTypes)))
            {

                int shipSize = (int)shipType;
                bool validCoordinate = false;

                while (!validCoordinate)
                {

                    PrintDeployShipMenu(board, player, shipType);
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
                        string orientationInput = AskForShipOrientation();
                        (int x, int y) = inputManager.TranslateCoordinates(shipCoordinates);
                        List<Square> shipElements = new List<Square>();
                        bool isVertical = PlaceShipOnBoard(board, (x, y), shipSize, orientationInput, shipElements);
                        AddShipToFleet(shipElements, shipType, isVertical, player);
                        validCoordinate = true;

                    }

                }

            }
        }

        private void AddShipToFleet(List<Square> shipElements, ShipTypes shipType, bool isVertical, Player player)
        {
            Ship ship = new Ship(shipElements, shipType);
            ship.IsVertical = isVertical;
            player.Fleet.Add(ship);
            shipElements.Clear();


        }
    }
 }

