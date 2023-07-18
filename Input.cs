using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Input
    {

        public int GetDigitInput()
        {
            var UserInput = Console.ReadKey();
            if (char.IsDigit(UserInput.KeyChar))
            {
                return Convert.ToInt32(UserInput);
            }
            else
            {
                return -1;
            }


        }

        public string GetStringInput()
        {
            string UserInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(UserInput))
            {
                return UserInput;
            }
            else
            {
                return "Invalid Input";
            }
        }
    }
}
