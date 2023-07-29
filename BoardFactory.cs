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
        private List<(int, int)> offsets = new List<(int, int)>
    {
        (-1, 0), (1, 0), (0, -1), (0, 1), // Left, Right, Up, Down
        (-1, -1), (-1, 1), (1, -1), (1, 1) // Diagonal neighbors
    };



        // ---------



        private bool CanPlaceShip(Board board, (int x, int y) coordinates)
        {


            if (board.ocean[coordinates.x, coordinates.y].SquerStatus == SquareStatus.Empty)
            {
                foreach ((int offsetX, int offsetY) in offsets)
                {
                    int neighbourX = coordinates.x + offsetX;
                    int neighbourY = coordinates.y + offsetY;
                    if (neighbourX >= 0 && neighbourX < (int)FixedVariables.BoardSize && neighbourY >= 0 && neighbourY < (int)FixedVariables.BoardSize)
                    {
                        if (board.ocean[neighbourX, neighbourY].SquerStatus == SquareStatus.Ship)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;


        }

        public void PrepareRandomBoard(Board board)
        {
            foreach (ShipTypes shipType in Enum.GetValues(typeof(ShipTypes)))
            {
                bool placed = false;
                while (!placed)
                {
                    Ship ship = new Ship(shipType);
                    ship.Elements = new List<Square>((int)shipType);
                    placed = RandomPlacement(board, (int)shipType, ship);
                }

            }
        }
        public bool RandomPlacement(Board board, int size, Ship ship)
        {
            List<(int x, int y)> freeCoordinates = new List<(int x, int y)>();

            for (int i = 0; i < (int)FixedVariables.BoardSize; i++)
            {
                for (int j = 0; j < (int)FixedVariables.BoardSize; j++)
                {
                    if (board.GetSquareAtPosition((i, j)).SquareStatus == SquareStatus.Empty)
                    {
                        freeCoordinates.Add((i, j));
                    }
                }
            }

            bool placed = false;

            while (freeCoordinates.Count > 0 && !placed)
            {
                int randomIndex = new Random().Next(0, freeCoordinates.Count);
                var randomCoordinate = freeCoordinates[randomIndex];
                freeCoordinates.RemoveAt(randomIndex);

                if (CanPlaceShip(board, randomCoordinate))
                {
                    bool isVertical = false;
                    PlaceShipOnBoard(board, randomCoordinate, size, RandomOrientation(), ship.Elements, isVertical);
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
            Console.WriteLine($"Player {player.Name}. Deploy your fleet!");
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


        private bool PlaceShipOnBoard(Board board, (int x, int y) startCoordinates, int shipSize, string orientationInput, List<Square> shipElements, bool isVertical)
        {

            bool shipPut = false;
            switch (orientationInput)
            {
                case "H":
                    isVertical = false;
                    shipPut = PutShipHorizontaly(startCoordinates, shipSize, board, shipElements);
                    break;
                case "V":
                    isVertical = true;
                    shipPut = PutShipVerticaly(startCoordinates, shipSize, board, shipElements);

                    break;
            }
            return shipPut;
        }

        public bool PutShipHorizontaly((int x, int y) startCoordinates, int shipSize, Board board, List<Square> shipElements)
        {
            List<(int, int)> possiblePlacment = new List<(int, int)>();
            int count = 0;
            bool shipPut = true;
            if (startCoordinates.y + shipSize - 1 < (int)FixedVariables.BoardSize)
            {
                while (count < shipSize)
                {
                    possiblePlacment.Add((startCoordinates.x, startCoordinates.y + count));
                    count++;
                }
            }
            else
            {
                while (count < shipSize)
                {
                    possiblePlacment.Add((startCoordinates.x, startCoordinates.y - count));
                    count++;
                }
            }

            foreach ((int, int) placment in possiblePlacment)
            {
                if (!CanPlaceShip(board, placment))
                {
                    shipPut = false;
                    possiblePlacment.Clear();
                    break;

                }
            }
            if (shipPut)
            {
                foreach ((int x, int y) placment in possiblePlacment)
                {
                    board.ocean[placment.x, placment.y].SquerStatus = SquareStatus.Ship;
                }
            }

            return shipPut;
        }



        private bool PutShipVerticaly((int x, int y) startCoordinates, int shipSize, Board board, List<Square> shipElements)
        {
            List<(int, int)> possiblePlacment = new List<(int, int)>();
            int count = 0;
            bool shipPut = true;
            if (startCoordinates.x + shipSize - 1 < (int)FixedVariables.BoardSize)
            {
                while (count < shipSize)
                {
                    possiblePlacment.Add((startCoordinates.x + count, startCoordinates.y));
                    count++;
                }
            }
            else
            {
                while (count < shipSize)
                {
                    possiblePlacment.Add((startCoordinates.x - count, startCoordinates.y));
                    count++;
                }
            }

            foreach ((int, int) placment in possiblePlacment)
            {
                if (!CanPlaceShip(board, placment))
                {
                    shipPut = false;
                    possiblePlacment.Clear();
                    break;

                }
            }
            if (shipPut)
            {
                foreach ((int x, int y) placment in possiblePlacment)
                {
                    board.ocean[placment.x, placment.y].SquerStatus = SquareStatus.Ship;
                }
            }

            return shipPut;
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
                        (int x, int y) = inputManager.TranslateCoordinates(shipCoordinates);

                        List<Square> shipElements = new List<Square>();
                        bool isVertical = false;
                        string orientationInput = AskForShipOrientation();
                        if (!PlaceShipOnBoard(board, (x, y), shipSize, orientationInput, shipElements, isVertical))
                        {
                            displayManager.InvalidCoordinate();
                            Thread.Sleep(1000);
                            continue;
                        }
                        AddShipToFleet(shipElements, shipType, isVertical, player);
                        validCoordinate = true;

                    }

                }

            }
        }

        private void AddShipToFleet(List<Square> shipElements, ShipTypes shipType, bool isVertical, Player player)
        {
            Ship ship = new Ship(shipType);
            ship.Elements = shipElements;

            ship.IsVertical = isVertical;
            player.Fleet.Add(ship);
            shipElements.Clear();


        }
    }
}

