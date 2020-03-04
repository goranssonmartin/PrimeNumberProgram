using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberLibrary
{
    public class PrimeNumberChecker
    {
        static List<int> listOfPrimeNumbers = new List<int>();

        public static int ConsoleHandler(string input)
        {
            input = input.ToLower();
            if (input == "stop")
            {
                return 1;
            }
            else if (input == "print")
            {
                return 2;
            }
            else if (input == "next")
            {
                return 3;
            }
            else if (int.TryParse(input, out int result))
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        public static bool HandleInputNumber(int inputNumber)
        {
            if (inputNumber <= 1)
            {
                return false;
            }
            else if (inputNumber == 2)
            {
                return true;
            }
            else if (inputNumber % 2 == 0)
            {
                return false;
            }
            var boundary = (int)Math.Floor(Math.Sqrt(inputNumber));

            for (int i = 3; i <= boundary; i += 2)
                if (inputNumber % i == 0)
                {
                    return false;
                }

            return true;
        }
        public static string AddToList(int intInput) {
            if (!listOfPrimeNumbers.Contains(intInput) && HandleInputNumber(intInput))
            {
                listOfPrimeNumbers.Add(intInput);
                return intInput + " added as a prime number\n";
            }
            else if (listOfPrimeNumbers.Contains(intInput) && HandleInputNumber(intInput)) {
                return intInput + " is a prime number, but is already stored";
            }
            else {
                return intInput + " is not a prime number\n";
            }
        }

        public static List<int> ReturnListOfStoredPrimeNumbers() {
            return listOfPrimeNumbers;
        }
        public static int FindNextPrimeNumber(int highestStoredNumber)
        {
            highestStoredNumber++;
            if (HandleInputNumber(highestStoredNumber))
            {
                return highestStoredNumber;
            }

            else
            {
                return FindNextPrimeNumber(highestStoredNumber);
            }
        }
    }
}
