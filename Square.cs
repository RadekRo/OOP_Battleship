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

        public string GetCharacter(SquareStatus status)
        {
            string result = null;
            switch ((int)status)
            {
                case 0:
                    result = "\u224B";
                    break;
                case 1:
                    result = "\u25CC";
                    break;
                case 2:
                    result = "\u2388";
                    break;
                case 3:
                    result = "\u2BCC";
                    break;
                case 4:
                    result = "\u2737";
                    break;
            }
            return result;
        }
    }
}
