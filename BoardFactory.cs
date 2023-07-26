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

        public void ManualPlacement(Board board)
        {

            for (int i = 1; i < Enum.GetNames(typeof(ShipType)).Length; i++)
            {
                ShipType shipType = (ShipType)i;
                int shipSize = (int)shipType;
                bool validCoordinate = false;

                while (!validCoordinate)
                {
                    Console.Clear();
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
                        board.ocean[x, y].SquerStatus = SquareStatus.ship;
                        validCoordinate = true;
                    }

                }
                //board.ocean[0, i].SquerStatus = SquareStatus.ship;
                //               DigitShapes; 
            }
        }
    }
}
