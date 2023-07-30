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
        public SquareStatus SquereStatus;

        public Square((int x, int y) position)
        {
            this.Position = position;

        }



        public string GetCharacter()
        {
            string result = "";
            switch ((int)this.SquereStatus)
            {
                case 0:
                    result = "~";
                    break;
                case 1:
                    result = "M";
                    break;
                case 2:
                    result = "S";
                    break;
                case 3:
                    result = "H";
                    break;
                case 4:
                    result = "X";

                    break;
            }
            return result;
        }

        public void ChangeSquereStatus(SquareStatus status)
        {
            SquereStatus = status;

        }
    }
}
