namespace OOP_Battleship
{
    class ComputerPlayerEasy : Player
    {
        private string _name = "CPU";
        public override (int x, int y) GetShootCoordinates()
        {
            Random r = new Random();
            return (r.Next(0, 9), r.Next(0, 9));

        }

        public virtual bool AreCoordinatsGood((int x, int y) coordinates, Board board)
        {
            Square squer = board.ocean[coordinates.x, coordinates.y];
            return squer.SquerStatus == "empty";

        }

        public override string Shoot(Player oponent, (int x, int y) shootCoordinates, Board board)
        {
            if (shootCoordinates == (0, 0))
                do
                {
                    shootCoordinates = GetShootCoordinates();
                } while (!AreCoordinatsGood(shootCoordinates, board));
            List<Ship> oponentFleet = oponent.Fleet;
            for (int i = 0; i < oponentFleet.Count; i++)
            {
                string shootResult = CheckIfHit(shootCoordinates, oponentFleet[i]);
                if (shootResult == "Hit!")
                {
                    if (CheckIfShipSink(shootResult, oponentFleet[i]))
                    {
                        ShipSink(oponentFleet[i]);
                        oponent.CheckIfAllSunk();
                        return "Ship sunk!";
                    }
                    return "Ship hit!";
                }
            }
            return "Miss!";


        }
    }
}
