using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CostParticipationApp
{
    public class MainBackend
    {
        ////// FINAL OPERATION
        public static Dictionary<string, decimal> Settlement(Dictionary<string, decimal> peopleAndAmount, decimal howmuchis, decimal price)
        {
            Dictionary<string, decimal> settlement = new Dictionary<string, decimal>();

            foreach (KeyValuePair<string, decimal> entry in peopleAndAmount)
            {
                decimal howmuchtaken_percent = (entry.Value / howmuchis);
                decimal payment = howmuchtaken_percent * price;

                settlement.Add(entry.Key, Math.Round(payment, 2));
            }

            return settlement;
        }

        ////// PEOPLE AND AMOUNT ITERATION
        ////// Auto calculation for penultimate participant
        public static decimal Penultimate(Dictionary<string, decimal> peopleAndAmount, decimal howmuch)
        {
            decimal soFarSum = AmountValidation.SumAmount(peopleAndAmount);
            decimal lastAmount = howmuch - soFarSum;
            return lastAmount;
        }
        public static Dictionary<string, decimal> PeopleIteration(int participants, decimal howmuch)
        {
            Dictionary<string, decimal> peopleAndAmount = new Dictionary<string, decimal>();

            while (true)
            {
                if (peopleAndAmount.Count == 0)
                {
                    Console.Write(Variables.Strings[3] + "1" + ": ");
                    string name = Console.ReadLine();

                    Console.Write(Variables.Strings[4]);
                    decimal lastInput = InputValidation.ValDecimal(Console.ReadLine(), Variables.Strings[4]);
                    decimal amount = AmountValidation.ValidateAmount(howmuch, lastInput, Variables.Strings[4]);

                    peopleAndAmount.Add(name, amount);
                }
                else
                {
                    for (int i = 1; i < participants; i++)
                    {
                        Console.Write(Variables.Strings[3] + (i + 1).ToString() + ": ");
                        string name = Console.ReadLine();

                        if (i == participants - 1)
                        {
                            peopleAndAmount.Add(name, Penultimate(peopleAndAmount, howmuch));
                            break;
                        }

                        Console.Write(Variables.Strings[4]);
                        // Last amount user input
                        decimal lastInput = InputValidation.ValDecimal(Console.ReadLine(), Variables.Strings[4]);
                        decimal amount = AmountValidation.ValidateAmount(peopleAndAmount, howmuch, lastInput, Variables.Strings[4]);

                        peopleAndAmount.Add(name, amount);
                    }
                    break;
                }
            }

            return peopleAndAmount;
        }
    }
}
