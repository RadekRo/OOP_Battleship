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
        public bool IsAlive { get; set; } = true;

        public int Number { get; set; }


        private (int x, int y) GetShootCoordinates()
        {
            Input input = new Input();
            string coordinates;
            do
            {
                Console.WriteLine("Input Coordinates");
                coordinates = input.GetStringInput();
            }
            while (input.ValidateStringInput(coordinates) && input.ValidateCoordinates(coordinates));
            return input.TranslateCoordinates(coordinates);

        }

        private string CheckIfHit((int x, int y) shootCoordinates, Ship ship)
        {

            foreach (var squer in ship)
            {
                if (shootCoordinates == squer.Position && squer.SquerStatus == "ship")
                {
                    squer.SquerStatus = "hit";
                    return "Hit!";

                }
            }
            return "Miss!";
        }

        private bool CheckIfShipSink(string shootResult, Ship ship)
        {
            if (shootResult == "Hit")
            {
                return ship.TrueForAll(ship.squer.SquerStatus == "hit");
            }
            return false;
        }

        private void ShipSink(Ship ship)
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





    }


}
