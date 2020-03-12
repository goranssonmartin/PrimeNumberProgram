using System;
using System.Linq;
using PrimeNumberLibrary;

namespace PrimeNumberProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool loopBoolean = true;
            Console.WriteLine("Type a number to check if it's a prime number, \"stop\" to quit, \"print\" to print all the added numbers,");
            Console.WriteLine("\"next\" to add the next prime number based on the stored ones");
            Console.WriteLine("or \"clear\" to clear the list of prime numbers\n");
            while (PrimeNumberChecker.loopBoolean)
            {
                string input = Console.ReadLine();
                PrimeNumberChecker.InputHandler(input);
            }
        }
    }
}
