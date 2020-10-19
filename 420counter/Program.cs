using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Globalization;
using System.Drawing;

namespace CostParticipationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // How much really is
            decimal howmuch;
            // The price
            decimal price;
            // How many participants
            int participants;
            // Dictionary for further calculations
            Dictionary<string, decimal> PeopleAndAmount = new Dictionary<string, decimal>();
            // Final settlement
            Dictionary<string, decimal> FinalSettlement = new Dictionary<string, decimal>();
            // String variables
            Dictionary<int, string> Text = Variables.Strings;

            Console.Write(Text[0]);
            howmuch = InputValidation.ValDecimal(Console.ReadLine(), Text[0]);

            Console.Write(Text[1]);
            price = InputValidation.ValDecimal(Console.ReadLine(), Text[1]);

            Console.Write(Text[2]);
            participants = InputValidation.ValInteger(Console.ReadLine(), Text[2]);


            if (participants > 1)
            {
                PeopleAndAmount = MainBackend.PeopleIteration(participants, howmuch);
            }
            else
            {
                QuitApp.Exit();
            }

            FinalSettlement = MainBackend.Settlement(PeopleAndAmount, howmuch, price);
            Console.Beep();
            Console.WriteLine(Text[6]);
            foreach (KeyValuePair<string, decimal> entry in FinalSettlement)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value.ToString());
            }

            Console.ReadLine();
        }
    }
}
