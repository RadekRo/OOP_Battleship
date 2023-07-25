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
        public List<Ship> Fleet { get; set; }
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

            for (int i = 0; i < (int)ship.ShipType; i++)
            {
                Square squer = ship.elements[i];
                if (shootCoordinates == squer.Position && squer.SquerStatus == SquareStatus.ship)
                {
                    squer.SquerStatus = SquareStatus.hit;
                    return "Hit!";

                }
            }
            return "Miss!";
        }

        protected bool CheckIfShipSink(string shootResult, Ship ship)
        {

            List<Square> list = ship.elements;
            return list.All(n => n.SquerStatus == SquareStatus.hit);

        }

        protected void ShipSink(Ship ship)
        {
            for (int i = 0; i < ship.elements.Count; i++)
            {
                Square square = ship.elements[i];
                square.SquerStatus = SquareStatus.sink;
            }

        }

        public virtual string Shoot(Player oponent, (int x, int y) shootCoordinates)
        {
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

        public void CheckIfAllSunk()
        {
            int fleetSize = this.Fleet.Count;
            foreach (Ship ship in this.Fleet)
            {
                if (ship.ShipStatus == "sink")
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
