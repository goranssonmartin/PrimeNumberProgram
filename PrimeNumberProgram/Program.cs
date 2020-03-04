﻿using System;
using System.Collections.Generic;
using System.Linq;
using PrimeNumberLibrary;

namespace PrimeNumberProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopBoolean = true;
            Console.WriteLine(@"Type a number to check if it's a prime number, ""stop"" to quit, ""print"" to print all the added numbers");
            Console.WriteLine("or \"next\" to add the next prime number based on the stored ones\n");
            while (loopBoolean)
            {
                var input = Console.ReadLine();

                if (PrimeNumberChecker.ConsoleHandler(input) == 1)
                {
                    loopBoolean = false;
                }

                else if (PrimeNumberChecker.ConsoleHandler(input) == 2)
                {
                    if (PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count > 0)
                    {
                        foreach (var storedNumbers in PrimeNumberChecker.ReturnListOfStoredPrimeNumbers())
                        {
                            Console.WriteLine(storedNumbers);
                        }
                        Console.WriteLine("");
                    }
                    else {
                        Console.WriteLine("No stored numbers to print");
                    }
                }

                else if (PrimeNumberChecker.ConsoleHandler(input) == 3)
                {
                    if (PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() > 0)
                    {
                        int nextPrimeNumber = PrimeNumberChecker.FindNextPrimeNumber(PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Max());
                        PrimeNumberChecker.AddToList(nextPrimeNumber);
                        Console.WriteLine(nextPrimeNumber + " added as the next prime number\n");
                    }
                    else
                    {
                        Console.WriteLine("No saved prime numbers to compare\n");
                    }
                }

                else if (PrimeNumberChecker.ConsoleHandler(input) == 4)
                {
                    Console.WriteLine(PrimeNumberChecker.AddToList(int.Parse(input)));
                }

                else
                {
                    Console.WriteLine("\"" + input + "\" is not a proper command or a number\n");
                }
            }

        }


    }
}
