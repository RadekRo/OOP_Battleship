using OOP_Battleship;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{

    internal class ComputerPlayerNormal : ComputerPlayerEasy
    {
        /*
        public HashSet<(int, int)> SquersToExclude = new HashSet<(int, int)>();
        public HashSet<(int, int)> PositionToCheck = new HashSet<(int, int)>();
        private List<(int, int)> offsets = new List<(int, int)>
    {
        (-1, 0), (1, 0), (0, -1), (0, 1), // Left, Right, Up, Down
        (-1, -1), (-1, 1), (1, -1), (1, 1) // Diagonal neighbors
    };

        private List<(int, int)> LastShootShip = new List<(int, int)>();
        private bool WasLastShootHit = false;
        private (int x, int y) LastShoot;


        public override (int x, int y) GetShootCoordinates()
        {
            if (PositionToCheck.Count > 0)
            {
                (int x, int y) = PositionToCheck.First();
                PositionToCheck.Remove((x, y));
                return (x, y);
            }
            else
            {
                return base.GetShootCoordinates();
            }
        }
        public override bool AreCoordinatsGood((int x, int y) coordinates, Board board)
        {
            Square square = board.ocean[coordinates.x, coordinates.y];
            return square.SquerStatus == SquareStatus.Empty && !SquersToExclude.Contains(coordinates);
        }


        private void FindSquaresToExclude(Board board)
        {

            foreach (Square s in board.ocean)
            {
                if (s.SquerStatus == SquareStatus.Sink)
                {
                    (int x, int y) position = s.Position;
                    SearchAroundPosition(board, SquersToExclude, position);
                }
            }
        }


        public override ShootResult Shoot(Player oponent, (int x, int y) shootCoordinates)
        {
            LastShoot = shootCoordinates;
            List<Ship> oponentFleet = oponent.Fleet;
            for (int i = 0; i < oponentFleet.Count; i++)
            {
                ShootResult shootResult = CheckIfHit(shootCoordinates, oponentFleet[i]);
                if (shootResult == ShootResult.Hit)
                {
                    WasLastShootHit = true;
                    LastShootShip.Add(shootCoordinates);
                    if (oponentFleet[i].CheckIfShipSink())
                    {
                        oponentFleet[i].ShipSink();
                        oponent.CheckIfAllSunk();
                        WasLastShootHit = false;
                        LastShootShip.Clear();
                        PositionToCheck.Clear();
                        return ShootResult.Sunk;
                    }

                    return ShootResult.Hit;
                }
            }
            WasLastShootHit = false;
            return ShootResult.Miss;

        }

        private void SearchAroundPosition(Board board, HashSet<(int, int)> list, (int x, int y) position = default)
        {
            position = (position == default) ? LastShoot : position;
            foreach ((int offsetX, int offsetY) in offsets)
            {
                int neighborX = position.x + offsetX;
                int neighborY = position.y + offsetY;

                if (neighborX >= 0 && neighborX < (int)FixedVariables.BoardSize && neighborY >= 0 && neighborY < (int)FixedVariables.BoardSize)
                {
                    Square s = board.GetSquareAtPosition((neighborX, neighborY));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        list.Add((neighborX, neighborY));
                    }
                }
            }
        }
        private void SearchHorizontalForShip((int x, int y) firstHit, Board board)
        {
            PositionToCheck.Clear();
            for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
            {
                if (firstHit.y - i > 0)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x, firstHit.y - i));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x, firstHit.y - i));
                    }
                }
                if (firstHit.y + i < (int)FixedVariables.BoardSize)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x, firstHit.y + i));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x, firstHit.y + i));
                    }
                }
            }
        }

        private void SearchVerticalForShip((int x, int y) firstHit, Board board)
        {
            PositionToCheck.Clear();
            for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
            {
                if (firstHit.x - i > 0)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x - i, firstHit.y));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x - i, firstHit.y));
                    }
                }
                if (firstHit.y + i < (int)FixedVariables.BoardSize)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x + i, firstHit.y));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x + i, firstHit.y));
                    }
                }
            }
        }
        private void SearchHorizontalAfterMiss((int x, int y) firstHit, Board board)
        {
            if (LastShoot.y > firstHit.y)
            {
                PositionToCheck.Clear();
                for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x, firstHit.y - i));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x, firstHit.y - i));
                    }
                }
            }
            else
            {
                PositionToCheck.Clear();
                for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x, firstHit.y + i));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x, firstHit.y + 1));
                    }
                }
            }
        }



        private void SearchVerticalAfterMiss((int x, int y) firstHit, Board board)
        {
            if (LastShoot.y > firstHit.y)
            {
                PositionToCheck.Clear();
                for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x - i, firstHit.y));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x - i, firstHit.y));
                    }
                }
            }
            else
            {
                PositionToCheck.Clear();
                for (int i = 1; i < (int)FixedVariables.MaxShipSize; i++)
                {
                    Square s = board.GetSquareAtPosition((firstHit.x + i, firstHit.y));
                    if (s.SquerStatus == SquareStatus.Empty)
                    {
                        PositionToCheck.Add((firstHit.x - i, firstHit.y));
                    }
                }
            }


        }



        public void GetPositionToCheck(Board board)
        {
            if (WasLastShootHit)
            {
                if (LastShootShip.Count == 1)
                {
                    SearchAroundPosition(board, PositionToCheck);
                }
                else if (LastShootShip.Count > 1)
                {
                    (int x, int y) firstHit = LastShootShip[0];
                    (int x, int y) lastHit = LastShootShip.Last();
                    if (firstHit.y == lastHit.y) // horizontal
                    {
                        SearchHorizontalForShip(firstHit, board);
                    }
                    else  // vertical
                    {

                        SearchVerticalForShip(firstHit, board);
                    }
                }
            }

            else if (LastShootShip.Count > 0)
            {
                (int x, int y) firstHit = LastShootShip[0];
                (int x, int y) lastHit = LastShootShip.Last();
                if (firstHit.y == lastHit.y) // horizontal
                {
                    SearchHorizontalAfterMiss(firstHit, board);
                }
                else
                {
                    SearchVerticalAfterMiss(firstHit, board);
                }
            }
        }

        public override ShootResult CPUMechanic(Board board, Player oponent)
        {
            (int x, int y) shootCoordinats = PrepereShootCoordinates(board);
            ShootResult message = Shoot(oponent, shootCoordinats);
            GetPositionToCheck(board);
            FindSquaresToExclude(board);
            return message;
        }
        */
    }
}
