﻿using System;
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

            if (board.GetSquareAtPosition(initialPos).SquereStatus != SquareStatus.Empty) return false;

            for (int i = 0; i < size; i++)
            {
                int posX = ship.IsVertical ? initialPos.x : initialPos.x + i;
                int posY = ship.IsVertical ? initialPos.y = initialPos.y + i : initialPos.y;

                if (board.GetSquareAtPosition((posX, posY)).SquereStatus != SquareStatus.Empty) return false;

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
                    if (board.GetSquareAtPosition((i, j)).SquereStatus == SquareStatus.Empty)
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
                    PlaceShipOnBoard(board, randomCoordinate, size, RandomOrientation());
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


        private List<Square> PlaceShipOnBoard(Board board, (int x, int y) startCoordinates, int shipSize, string orientationInput)
        {

            board.ocean[startCoordinates.x, startCoordinates.y].SquereStatus = SquareStatus.Ship;

            List<Square> shipElements = new List<Square>();
            int count = shipSize - 1;
            switch (orientationInput)
            {
                case "H":

                    shipElements.AddRange(PutShipHorizontaly(startCoordinates, shipSize, count, board));
                    break;
                case "V":

                    shipElements.AddRange(PutShipVerticaly(startCoordinates, shipSize, count, board));

                    break;
            }
            return shipElements;
        }

        public List<Square> PutShipHorizontaly((int x, int y) startCoordinates, int shipSize, int count, Board board)
        {
            List<Square> shipElements = new List<Square>();
            if (startCoordinates.y + shipSize  < (int)FixedVariables.BoardSize)
            {
                while (count >= 0)
                {
                    board.UpdateOcean(startCoordinates.x, startCoordinates.y + count, SquareStatus.Ship);
                    Square s = new Square((startCoordinates.x, startCoordinates.y + count));
                    s.SquereStatus = SquareStatus.Ship;
                    shipElements.Add(s);
                    count--;

                }
            }
            else
            {
                while (count >= 0)
                {
                    board.UpdateOcean(startCoordinates.x, startCoordinates.y - count, SquareStatus.Ship);
                    Square s = new Square((startCoordinates.x, startCoordinates.y - count));
                    s.SquereStatus = SquareStatus.Ship;
                    shipElements.Add(s);
                    count--;

                }

            }
            return shipElements;
        }

        private List<Square> PutShipVerticaly((int x, int y) startCoordinates, int shipSize, int count, Board board)
        {
            List<Square> shipElements = new List<Square>();
            if (startCoordinates.x + shipSize < (int)FixedVariables.BoardSize)
            {
                while (count >= 0)
                {
                    board.UpdateOcean(startCoordinates.x + count, startCoordinates.y, SquareStatus.Ship);
                    Square s = new Square((startCoordinates.x + count, startCoordinates.y));
                    s.SquereStatus = SquareStatus.Ship;
                    shipElements.Add(s);
                    count--;

                }
            }
            else
            {
                while (count >= 0)
                {

                    board.UpdateOcean(startCoordinates.x - count, startCoordinates.y, SquareStatus.Ship);
                    Square s = new Square((startCoordinates.x - count, startCoordinates.y));
                    s.SquereStatus = SquareStatus.Ship;
                    shipElements.Add(s);
                    count--;

                }

            }
            return shipElements;
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
                        List<Square> shipElements = PlaceShipOnBoard(board, (x, y), shipSize, orientationInput);

                        player.AddShipToFleet(shipElements, shipType);
                        validCoordinate = true;

                    }

                }

            }
        }


    }
}

