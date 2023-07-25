﻿
namespace OOP_Battleship
{

    internal class ComputerPlayerNormal : ComputerPlayerEasy
    {
        public HashSet<Square> SquersToExclude { get; set; }


        public override bool AreCoordinatsGood((int x, int y) coordinates, Board board)
        {
            Square square = board.ocean[coordinates.x, coordinates.y];
            return square.SquerStatus == "empty" && !SquersToExclude.Contains(square);
        }

        public void ExcludeSquers(Board board)
        {

            HashSet<(int, int)> positionsToCheck = new HashSet<(int, int)>();
            foreach (Square square in board.ocean)
            {
                if (square.SquerStatus == "sink")
                {
                    (int x, int y) = square.Position;


                    if (x - 1 >= 0)
                    {
                        positionsToCheck.Add((x - 1, y));
                        if (y - 1 >= 0)
                        {
                            positionsToCheck.Add((x - 1, y - 1));
                            positionsToCheck.Add((x, y - 1));
                        }
                        if (y + 1 < 10)
                        {
                            positionsToCheck.Add((x - 1, y + 1));
                            positionsToCheck.Add((x, y + 1));
                        }


                    }
                    if (x + 1 < 10)
                    {
                        positionsToCheck.Add((x + 1, y));
                        if (y - 1 >= 0)
                        {
                            positionsToCheck.Add((x + 1, y - 1));
                            positionsToCheck.Add((x, y - 1));

                        }
                        if (y + 1 < 10)
                        {
                            positionsToCheck.Add((x + 1, y + 1));
                            positionsToCheck.Add((x, y + 1));

                        }



                    }
                }


            }
            foreach ((int, int) postition in positionsToCheck)

            {

                Square match = Array.Find(board.ocean, s => s.Position == postition);

            }
        }
    }