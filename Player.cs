using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Player
    {
        private string _name;
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

        public int PlayerNumber { get; set; }


        public (int x, int y) GetShootCoordinates()
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

        public string CheckIfHit((int x, int y) shootCoordinates, Ship ship, int length)
        {

            for (int i = 0; i < length; i++)
            {
                Square squer = ship.elements[i];
                if (shootCoordinates == squer.Position && squer.SquerStatus == "ship")
                {
                    squer.SquerStatus = "hit";
                    return "Hit!";

                }
            }
            return "Miss!";
        }

        public bool CheckIfShipSink(string shootResult, Ship ship)
        {
            if (shootResult == "Hit")
            {
                return ship.TrueForAll(ship.squer.SquerStatus == "hit");
            }
            return false;
        }

        public void ShipSink(Ship ship)
        {
            foreach (var squer in ship)
            {
                squer.SquerStatus = "sink";
            }
        }
        public string Shoot(Player oponent)
        {
            (int x, int y) coordinates = GetShootCoordinates();
            foreach (var ship in oponent.Fleet)
            {
                string shootResult = CheckIfHit(coordinates, ship);
                if (shootResult == "hit")
                {
                    if (CheckIfShipSink(shootResult, ship))
                    {
                        ShipSink(ship);
                        return "Ship sunk!";
                    }
                    return "Ship hit!";
                }
            }
            return "Miss!";

        }

        public void CheckIfAlive()

        {
            int fleetSize = this.Fleet.Count;
            foreach (var ship in this.Fleet)
            {
                if (ship.TrueForAll(ship.squer.SquerStatus == "sink"))
                {
                    fleetSize--;
                }
            }
            if (fleetSize == 0)
            {
                this.IsAlive = false;
            }
        }



    }


}
