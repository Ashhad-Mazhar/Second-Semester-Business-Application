using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class MiscLogic
    {
        public static bool ValidateNumericInput(string input)
        {
            // Used to make sure that the given input consists of numbers only.
            bool validInput = true;
            for (int idx = 0; idx < input.Count(); idx++)
            {
                if (!((int)input[idx] >= 48 && (int)input[idx] <= 57))
                {
                    validInput = false;
                    break;
                }
            }
            return validInput;
        }
        public static bool ValidateMenuInput(string choice, int lowerLimit, int upperLimit)
        {
            // Used to validate the input in Admin menu screen.
            bool isInputCorrect = false;
            isInputCorrect = ValidateNumericInput(choice);
            if (isInputCorrect)
            {
                if (!(int.Parse(choice) >= lowerLimit && int.Parse(choice) <= upperLimit))
                {
                    isInputCorrect = false;
                }
            }
            return isInputCorrect;
        }
        public static bool ValidateTextInput(string Username)
        {
            // Used to make sure that a given username does not contain numbers and special characters.
            bool isInputCorrect = true;
            for (int idx = 0; idx < Username.Length; idx++)
            {
                if (!(((int)Username[idx] >= 65 && (int)Username[idx] <= 90) || ((int)Username[idx] >= 97 && (int)Username[idx] <= 122) || ((int)Username[idx] == 32)))
                {
                    isInputCorrect = false;
                    break;
                }
            }
            return isInputCorrect;
        }
    }
}
