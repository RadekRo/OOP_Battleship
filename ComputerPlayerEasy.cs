using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class ComputerPlayerEasy : Player
    {
        public override (int x, int y) GetShootCoordinates()
        {
            Random r = new Random();
            return (r.Next(0, 9), r.Next(0, 9));

        }
    }
}
