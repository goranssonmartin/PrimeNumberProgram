using System;
using System.Linq;
using PrimeNumberLibrary;

namespace PrimeNumberProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopBoolean = true;
            Console.WriteLine("Type a number to check if it's a prime number, \"stop\" to quit, \"print\" to print all the added numbers,");
            Console.WriteLine("\"next\" to add the next prime number based on the stored ones");
            Console.WriteLine("or \"clear\" to clear the list of prime numbers\n");
            while (loopBoolean)
            {
                string input = Console.ReadLine();
                int inputReturnValue = PrimeNumberChecker.InputHandler(input);
                //stop
                if (inputReturnValue == 1)
                {
                    loopBoolean = false;
                }

                //print
                else if (inputReturnValue == 2)
                {
                    if (PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count > 0)
                    {
                        foreach (var storedNumbers in PrimeNumberChecker.ReturnListOfStoredPrimeNumbers())
                        {
                            Console.WriteLine(storedNumbers);
                        }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("No stored numbers to print\n");
                    }
                }
                //next 
                else if (inputReturnValue == 3)
                {
                    if (PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() > 0)
                    {
                        int nextPrimeNumber = PrimeNumberChecker.FindNextPrimeNumber(PrimeNumberChecker.ReturnListOfStoredPrimeNumbers()[PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() - 1]);
                        PrimeNumberChecker.AddToList(nextPrimeNumber);
                        Console.WriteLine(nextPrimeNumber + " added as the next prime number\n");
                    }
                    else
                    {
                        Console.WriteLine("No stored prime numbers to compare\n");
                    }
                }
                //clear
                else if (inputReturnValue == 4)
                {
                    PrimeNumberChecker.ClearList();
                    Console.WriteLine("Cleared the list of stored prime numbers\n");
                }
                //valid number
                else if (inputReturnValue == 5)
                {
                    Console.WriteLine(PrimeNumberChecker.AddToList(int.Parse(input)));
                }
                //null input
                else if (inputReturnValue == 7)
                {
                    Console.WriteLine("Input cannot be null");
                }
                //invalid command or number
                else
                {
                    Console.WriteLine("\"" + input + "\" is not a proper command or a number\n");
                }
            }
        }
    }
}
