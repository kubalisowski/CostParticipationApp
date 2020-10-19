using System;
using System.Collections.Generic;
using System.Text;

namespace CostParticipationApp
{
    public class QuitApp
    {
        public static void Exit()
        {
            Console.Beep();
            Console.WriteLine(Variables.Strings[5]);
            System.Environment.Exit(0);
        }
    }
}
