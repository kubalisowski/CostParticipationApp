using System;
using System.Collections.Generic;
using System.Text;

namespace CostParticipationApp
{
    public class AmountValidation
    {
        /// Sum of already taken amounts
        public static decimal SumAmount(Dictionary<string, decimal> peopleAndAmount)
        {
            decimal sum = new decimal();
            foreach (KeyValuePair<string, decimal> entry in peopleAndAmount)
            {
                sum += entry.Value;
            }

            return sum;
        }

        /// Dictionary has got minimum 1 record added
        public static decimal ValidateAmount(Dictionary<string, decimal> peopleAndAmount, decimal howmuch, decimal lastInput, string message)
        {
            decimal sum = new decimal();
            decimal total = new decimal();
            decimal correctVariable = new decimal();

            // PeopleAndAmount dict without last added data
            sum = SumAmount(peopleAndAmount);
            // + last user input for total amount
            total = sum + lastInput;

            if (total > howmuch)
            {   
                while (total > howmuch)
                {
                    Console.WriteLine(Variables.Strings[8]);
                    Console.Write(message);
                    lastInput = InputValidation.ValDecimal(Console.ReadLine(), message);
                    correctVariable = lastInput;
                    total = lastInput + sum;
                }
            }
            else
            {
                correctVariable = lastInput;
            }

            return correctVariable;
        }
        /// Overload for an empty dictionary (first user input/first iteration)
        public static decimal ValidateAmount(decimal howmuch, decimal lastInput, string message)
        {
            decimal correctVariable = new decimal();

            if (lastInput > howmuch)
            {
                while (lastInput > howmuch)
                {
                    Console.WriteLine(Variables.Strings[8]);
                    Console.Write(message);
                    correctVariable = InputValidation.ValDecimal(Console.ReadLine(), message);
                    lastInput = correctVariable;
                }
            }
            else
            {
                correctVariable = lastInput;
            }

            return correctVariable;
        }
    }
}
