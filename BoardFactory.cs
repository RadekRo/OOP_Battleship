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

        public void ManualPlacement(Board board, string playerName, Player player)
        {

            for (int i = 1; i < Enum.GetNames(typeof(ShipTypes)).Length; i++)
            {
                ShipTypes shipType = (ShipTypes)i;
                int shipSize = (int)shipType;
                bool validCoordinate = false;
                string shipOrientation = "";
                while (!validCoordinate)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Player {playerName}. Deploy your fleet!");
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

                        if (shipSize > 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Player {playerName}. Deploy your fleet!");
                            Console.ResetColor();
                            Console.WriteLine("------------------------------");
                            displayManager.PrintBoard(board);
                            Console.WriteLine($"Placing {shipType} (size {shipSize})");
                            displayManager.AskForShipOrientation();
                            shipOrientation = inputManager.GetStringInput();
                            while (!inputManager.ValidateShipOrientation(shipOrientation))
                            {
                                displayManager.InvaliOrientationMessage();
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Player {playerName}. Deploy your fleet!");
                                Console.ResetColor();
                                Console.WriteLine("------------------------------");
                                displayManager.PrintBoard(board);
                                Console.WriteLine($"Placing {shipType} (size {shipSize})");
                                displayManager.AskForShipOrientation();
                                shipOrientation = inputManager.GetStringInput();
                                Console.Clear();
                            }
                        }

                        (int x, int y) = inputManager.TranslateCoordinates(shipCoordinates);
                        Square s = board.ocean[x, y];
                        s.SquerStatus = SquareStatus.ship;
                        List<Square> shipElements = new List<Square>();
                        shipElements.Add(s);
                        if (shipSize > 1)
                        {
                            if (shipOrientation.ToUpper() == "H")
                            {
                                if (y + shipSize < 10)
                                {
                                    int count = shipSize - 1;

                                    while (count > 0)
                                    {

                                        s = board.ocean[x, y + count];
                                        s.SquerStatus = SquareStatus.ship;
                                        shipElements.Add(s);
                                        count--;
                                    }

                                }
                                else
                                {
                                    int count = shipSize - 1;

                                    while (count > 0)
                                    {

                                        s = board.ocean[x, y - count];
                                        s.SquerStatus = SquareStatus.ship;
                                        shipElements.Add(s);
                                        count--;
                                    }
                                }
                            }
                            else
                            {
                                if (x + shipSize < 10)
                                {
                                    int count = shipSize - 1;

                                    while (count > 0)
                                    {

                                        s = board.ocean[x + count, y];
                                        s.SquerStatus = SquareStatus.ship;
                                        shipElements.Add(s);
                                        count--;
                                    }

                                }
                                else
                                {
                                    int count = shipSize - 1;

                                    while (count > 0)
                                    {

                                        s = board.ocean[x - count, y];
                                        s.SquerStatus = SquareStatus.ship;
                                        shipElements.Add(s);
                                        count--;
                                    }
                                }
                            }
                        }
                        Ship ship = new Ship(shipElements, shipType);
                        player.Fleet.Add(ship);
                        shipElements.Clear();

                        validCoordinate = true;
                    }

                }
                //board.ocean[0, i].SquerStatus = SquareStatus.ship;
            }
        }
        public void RandomPlacment(Board board, string playerName, Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player {playerName}. Deploy your fleet!");
            Console.ResetColor();
            Console.WriteLine("------------------------------");
            displayManager.PrintBoard(board);
            Thread.Sleep(1000);
            for (int i = 1; i < Enum.GetNames(typeof(ShipTypes)).Length; i++)
            {
                ShipTypes shipType = (ShipTypes)i;
                int shipSize = (int)shipType;
                bool validCoordinate = false;
                string shipOrientation = "";
                while (!validCoordinate)
                {
                    Random r = new Random();
                    (int x, int y) = (r.Next(0, 9), r.Next(0, 9));
                    if (shipSize > 1)
                    {
                        int choice = r.Next(0, 1);

                    }

                }
            }
        }
    }
}