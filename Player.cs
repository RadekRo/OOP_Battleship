using System.Xml.Serialization;

namespace OOP_Battleship
{
    public class Player
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
        public List<Ship> Fleet;
        public bool IsAlive { get; private set; } = true;

        public int PlayerNumber { get; set; }

        public Player()
        {
            Fleet = new List<Ship>();
        }

        public virtual (int x, int y) GetShootCoordinates()
        {
            Input input = new Input();
            string coordinates;
            do
            {
                Console.Write("Input Shot Coordinates: ");
                coordinates = input.GetStringInput();
            }
            while (!input.ValidateStringInput(coordinates) || !input.ValidateCoordinates(coordinates));
            return input.TranslateCoordinates(coordinates);

        }

        protected ShootResult CheckIfHit((int x, int y) shootCoordinates, Ship ship, Board board)
        {

            for (int i = 0; i < (int)ship.Type; i++)
            {
                
                if (shootCoordinates == ship.Elements[i].Position && ship.Elements[i].SquereStatus == SquareStatus.Ship)
                {
                    ship.Elements[i].ChangeSquereStatus(SquareStatus.Hit);
                    board.ocean[shootCoordinates.x, shootCoordinates.y].ChangeSquereStatus(SquareStatus.Hit);
                    ship.ChangeShipStatus(ShipStatus.damaged);
                    return ShootResult.Hit;

                }
            }
            board.ocean[shootCoordinates.x, shootCoordinates.y].ChangeSquereStatus(SquareStatus.Miss);
            return ShootResult.Miss;
        }


        public virtual ShootResult Shoot(Player oponent, (int x, int y) shootCoordinates, Board board)
        {
            List<Ship> oponentFleet = oponent.Fleet;
            for (int i = 0; i < oponentFleet.Count; i++)
            {
                ShootResult shootResult = CheckIfHit(shootCoordinates, oponentFleet[i], board);
                if (shootResult == ShootResult.Hit)
                {

                    if (oponentFleet[i].CheckIfShipSink())
                    {
                        oponentFleet[i].ShipSink();
                        oponent.CheckIfAllSunk();
                        return ShootResult.Sunk;
                    }
                    return ShootResult.Hit;
                }
            }
            return ShootResult.Miss;

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
            return !this.IsAlive;
        }
        public void AddShipToFleet(List<Square> shipElements, ShipTypes shipType)
        {
            Fleet.Add(new Ship(shipElements, shipType));
        }

    }

}


