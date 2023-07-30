namespace OOP_Battleship
{
    class ComputerPlayerEasy : Player
    {/*
        private string _name = "CPU";
        public override (int x, int y) GetShootCoordinates()
        {
            Random r = new Random();
            return (r.Next(0, (int)FixedVariables.BoardSize - 1), r.Next(0, (int)FixedVariables.BoardSize - 1));

        }

        public virtual bool AreCoordinatsGood((int x, int y) coordinates, Board board)
        {
            Square squer = board.ocean[coordinates.x, coordinates.y];
            return squer.SquerStatus == SquareStatus.Empty;

        }

        public (int x, int y) PrepereShootCoordinates(Board board)
        {
            (int x, int y) = GetShootCoordinates();
            while (!AreCoordinatsGood((x, y), board))
            {
                (x, y) = GetShootCoordinates();
            }
            return (x, y);
        }

        public virtual ShootResult CPUMechanic(Board board, Player oponent)
        {
            (int x, int y) coordinates = PrepereShootCoordinates(board);
            return Shoot(oponent, coordinates);

        }
        */
    }
}
