using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem
{
    internal class Utils
    {

        public static string continueText = "\n\nKlicka på valfri tangent för att fortsätta";

        public static string PromptUserForTextInput(string writeLineText)
        {
            string output = "";
            bool waitingForCorrectInput = true;

            while (waitingForCorrectInput)
            {
                try
                {
                    Console.Clear();
                    Console.Write(writeLineText);
                    string? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Inmatningen får inte vara tom\n\n");
                        WaitForEnterKey();
                    }
                    
                    else
                    {
                        if (input != null)
                        {
                            output = input;
                        }

                        waitingForCorrectInput = false;
                    }
                }

                catch 
                {
                    Utils.WaitForEnterKey();
                }                         
            }

            return output;

        }

        public static int PromptUserForNumericalInput(string attributeName)
        {
            int output = 0;
            bool waitingForCorrectInput = true;

            while (waitingForCorrectInput)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Var vänlig och fyll i " + attributeName + ": ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine
                            ("Var vänlig och använd siffor för att ange " +
                            attributeName);
                        Utils.WaitForEnterKey();
                        Console.Clear();
                    }

                    else
                    {
                        bool validInput = int.TryParse(input, out output);
                        if (validInput)
                        {                                                     
                            waitingForCorrectInput = false;                         
                        }

                        else
                        {
                            Utils.WaitForEnterKey();
                        }
                    }
                }

                catch 
                {
                    Utils.WaitForEnterKey();
                }
            }

            return output;

        }

      

        public static string[] GetRelatedText(int vehicleType, bool newObject)
        {
            string confirmationText = "skapad";

            if (!newObject)
            {
                confirmationText = "ändrad";
            }
           
            string[] uniqueVariableQuestion =
            {
                "Har bilen en taklucka?",
                "Har motorcyklen en siddel?",
                "hur många ton klarar lastbilen",
                "hur många batteri-timmar har el-scootern"
            };

            string[] creationText =
            {
                "Bilen är nu " + confirmationText,
                "Motorcykeln är nu " + confirmationText,
                "Lastbilen är nu "  + confirmationText,
                "El-scootern är nu "  + confirmationText
            };

            string[] outputArray =
            {
                uniqueVariableQuestion[vehicleType],
                creationText[vehicleType]
            };

            return outputArray;
        }
        
        public static void WaitForEnterKey()
        {
            while (true)
            {
                Console.WriteLine("\nVar vänlig och klicka ENTER för att fortsätta");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                    break;

                else
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning, var vänlig och klicka ENTER för att fortsätta");
                                                                 
            }            
        }
        
    }
}
