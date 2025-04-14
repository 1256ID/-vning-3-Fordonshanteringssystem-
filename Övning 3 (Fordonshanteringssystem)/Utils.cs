﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem
{
    internal class Utils
    {

        public static string tryAgainText = "Var vänlig och försök igen";
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
                        Console.WriteLine("Inmatningen får inte vara tom\n\n" + tryAgainText);
                        Console.ReadKey();
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
                    Console.WriteLine("Ogiltig inmatning\n\n" + tryAgainText);
                    Console.ReadKey();
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
                    Console.Write("Var vänlig och fyll i " + attributeName + ": ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine
                            ("Var vänlig och använd siffor för att ange " +
                            attributeName + continueText);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else
                    {
                        bool validInput = int.TryParse(input, out output);
                        if (validInput)
                        {
                            if (output < 0)
                            {
                                Console.WriteLine
                                    ("Var vänlig och använd ett positivt tal" + continueText);
                                Console.ReadKey();
                                Console.Clear();
                            }

                            else
                            {
                                waitingForCorrectInput = false;
                            }
                        }

                        else
                        {
                            Console.WriteLine(tryAgainText + continueText);
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }

                catch
                {
                    Console.WriteLine(tryAgainText + continueText);
                    Console.ReadKey();
                    Console.Clear();
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
    }
}
