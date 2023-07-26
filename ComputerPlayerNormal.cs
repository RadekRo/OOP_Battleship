using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class ComputerPlayerNormal : ComputerPlayerEasy
    {
        public List<Square> SquersToExclude;
        public HashSet<(int, int)> PositionToCheck;

        public override bool AreCoordinatsGood((int x, int y) coordinates, Board board)
        {
            Square square = board.ocean[coordinates.x, coordinates.y];
            return square.SquerStatus == SquareStatus.empty && !SquersToExclude.Contains(square);
        }

        public void GetPositionToCheck(Ship ship)
        {

            List<(int, int)> offsets = new List<(int, int)>
    {
        (-1, 0), (1, 0), (0, -1), (0, 1), // Left, Right, Up, Down
        (-1, -1), (-1, 1), (1, -1), (1, 1) // Diagonal neighbors
    };

            foreach (Square element in ship.Elements)
            {
                (int x, int y) = element.Position;

                foreach ((int offsetX, int offsetY) in offsets)
                {
                    int neighborX = x + offsetX;
                    int neighborY = y + offsetY;

                    if (neighborX >= 0 && neighborX < 10 && neighborY >= 0 && neighborY < 10)
                    {
                        PositionToCheck.Add((neighborX, neighborY));
                    }
                }
            }

        }
        public void FindSquaresToExclude(Board board)
        {

            foreach ((int, int) posiotion in PositionToCheck)
            {
                Square s = board.GetSquareAtPosition(posiotion);
                if (s.SquerStatus == SquareStatus.empty)
                {
                    this.SquersToExclude.Add(s);
                }
            }
        }
        public override string Shoot(Player oponent, (int x, int y) shootCoordinates)
        {
            List<Ship> oponentFleet = oponent.Fleet;
            for (int i = 0; i < oponentFleet.Count; i++)
            {
                string shootResult = CheckIfHit(shootCoordinates, oponentFleet[i]);
                if (shootResult == "Hit!")
                {
                    if (oponentFleet[i].CheckIfShipSink())
                    {
                        oponentFleet[i].ShipSink();
                        GetPositionToCheck(oponentFleet[i]);
                        oponent.CheckIfAllSunk();
                        return "Ship sunk!";
                    }
                    return "Ship hit!";
                }
            }
            return "Miss!";

        }


        public override string CPUMechanic(Board board, Player oponent)
        {
            (int x, int y) shootCoordinats = GetShootCoordinates();
            string message = Shoot(oponent, shootCoordinats);
            FindSquaresToExclude(board);
            return message;
        }

    }
}
