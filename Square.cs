using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Square
    {
        public (int x, int y) Position;
        public string SquerStatus;
        public Square((int x, int y) position, string status)
        {
            this.Position = position;
            this.SquerStatus = status;
        }
    }
}
