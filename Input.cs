using System.Text;
using System.Text.RegularExpressions;

namespace OOP_Battleship
{
    internal class Input
    {

        public Input()
        {

        }
        string invalidMessage = "Invalid input";
        public int GetDigitInput()
        {
            var userInput = Console.ReadKey();
            if (char.IsDigit(userInput.KeyChar))
            {
                return int.Parse(userInput.KeyChar.ToString());
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
        public (int x, int y) TranslateCoordinates(string validUserInput)
        {
            validUserInput = validUserInput.ToUpper();
            string letterPart = Regex.Match(validUserInput, @"[A-J]+").Value;
            string numberPart = Regex.Match(validUserInput, @"10|[1-9]").Value;
            int x = Convert.ToInt32(Encoding.ASCII.GetBytes(new[] { letterPart[0] })[0]) - 65;
            int y = Convert.ToInt32(numberPart) - 1;
            return (y, x);

        }
    }
}
