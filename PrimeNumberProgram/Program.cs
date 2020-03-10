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
                var input = Console.ReadLine();

                if (PrimeNumberChecker.InputHandler(input) == 1)
                {
                    loopBoolean = false;
                }

                else if (PrimeNumberChecker.InputHandler(input) == 2)
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

                else if (PrimeNumberChecker.InputHandler(input) == 3)
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

                else if (PrimeNumberChecker.InputHandler(input) == 4)
                {
                    PrimeNumberChecker.ClearList();
                    Console.WriteLine("Cleared the list of stored prime numbers\n");
                }

                else if (PrimeNumberChecker.InputHandler(input) == 5)
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
