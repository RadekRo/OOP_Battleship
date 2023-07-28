namespace OOP_Battleship
{
    class Player
    {
        private string? _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public List<Ship> Fleet = new List<Ship>();
        public bool IsAlive { get; private set; } = true;

        public int PlayerNumber { get; init; }


        public virtual (int x, int y) GetShootCoordinates()
        {
            Input input = new Input();
            string coordinates;
            do
            {
                Console.WriteLine("Input Coordinates");
                coordinates = input.GetStringInput();
            }
            while (!input.ValidateStringInput(coordinates) || !input.ValidateCoordinates(coordinates));
            return input.TranslateCoordinates(coordinates);

        }

        protected string CheckIfHit((int x, int y) shootCoordinates, Ship ship)
        {

            for (int i = 0; i < (int)ship.Type; i++)
            {
                Square squer = ship.Elements[i];
                if (shootCoordinates == squer.Position && squer.SquerStatus == SquareStatus.ship)
                {
                    squer.SquerStatus = SquareStatus.hit;
                    ship.ChangeShipStatus(ShipStatus.damaged);
                    return "Hit!";

                }
            }
            return "Miss!";
        }


        public virtual string Shoot(Player oponent, (int x, int y) shootCoordinates)
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
                        oponent.CheckIfAllSunk();
                        return "Ship sunk!";
                    }
                    return "Ship hit!";
                }
            }
            return "Miss!";

        }

        public void CheckIfAllSunk()
        {
            int fleetSize = this.Fleet.Count;
            foreach (Ship ship in this.Fleet)
            {
                if (ship.Status == ShipStatus.destroyed)
                {
                    fleetSize--;
                }
            }
            if (fleetSize == 0)
            {
                this.IsAlive = false;
            }

        }

        public bool IsPlayerDead()
        {
            return this.IsAlive;
        }

    }


}
