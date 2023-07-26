using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Ship
    {
        public List<Square> Elements;
        public ShipTypes Type { get; init; }
        public ShipStatus Status { get; private set; } = ShipStatus.normal;

        public Ship(List<Square> elements, ShipTypes type)
        {
            this.Elements = elements;
            this.Type = type;

        }
        public void ChangeShipStatus(ShipStatus status)
        {
            this.Status = status;
        }
    }
}
