using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Input
    {
        string invalidMessage = "Invalid input";
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
            var UserInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(UserInput))
            {
                return UserInput;
            }
            else
            {
                return invalidMessage;
            }
        }

        public bool ValidateOptionInput(int maxOptionNumber, int digitInput)
        {
            return (digitInput > 0 && digitInput <= maxOptionNumber);

        }

        public bool ValidateStringInput(string stringInput)
        {
            return (stringInput != invalidMessage);
        }


        public bool ValidateCoordinates(string userInput)
        {
            userInput = userInput.ToUpper();
            string pattern = @"^([A-J]([1-9]|10)|([1-9]|10)[A-J])$";
            return Regex.IsMatch(userInput, pattern, RegexOptions.IgnoreCase);
        }
        public (int x, int y) TranslateCoordinates(string userInput)
        {

        }
    }
}
