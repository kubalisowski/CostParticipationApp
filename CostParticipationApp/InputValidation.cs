using System;
using System.Collections.Generic;
using System.Text;

namespace CostParticipationApp
{
    public class InputValidation
    {
        // For Decimal
        public static decimal ValDecimal(string userInput, string message)
        {
            decimal correctInput;
            decimal correctVariable;
            while (true)
            {
                if (!Decimal.TryParse(userInput, out correctInput))
                {
                    Console.WriteLine(Variables.Strings[7]);
                    Console.Write(message);
                    userInput = Console.ReadLine();
                }
                else
                {
                    correctVariable = correctInput;
                    break;
                }
            }

            return correctVariable;
        }
        // For Int32
        public static int ValInteger(string userInput, string message)
        {
            int correctInput;
            int correctVariable;
            while (true)
            {
                if (!Int32.TryParse(userInput, out correctInput))
                {
                    Console.WriteLine(Variables.Strings[7]);
                    Console.Write(message);
                    userInput = Console.ReadLine();
                }
                else
                {
                    correctVariable = correctInput;
                    break;
                }
            }

            return correctVariable;
        }
    }
}
