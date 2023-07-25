using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Ship
    {
        public List<Square> elements;
        public ShipTypes ShipType { get; init; }
        public int ShipID { get; init; }

        public string ShipStatus { get; set; }

    }
}
