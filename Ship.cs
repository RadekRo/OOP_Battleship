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

        public bool CheckIfShipSink()
        {
            List<Square> list = this.Elements;
            return list.All(n => n.SquerStatus == SquareStatus.hit);
        }

        public void ShipSink()
        {
            for (int i = 0; i < this.Elements.Count; i++)
            {
                Square square = this.Elements[i];
                square.SquerStatus = SquareStatus.sink;
                this.ChangeShipStatus(ShipStatus.destroyed);
            }

        }
    }
}
