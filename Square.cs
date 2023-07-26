using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    public class Square
    {
        public (int x, int y) Position;
        public SquareStatus SquerStatus;

        public Square((int x, int y) position, SquareStatus status)
        {
            this.Position = position;
            this.SquerStatus = status;
        }

        public string GetCharacter()
        {
            string result = "";
            switch ((int)this.SquerStatus)
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
