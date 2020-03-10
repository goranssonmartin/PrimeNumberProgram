using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberLibrary
{
    public class PrimeNumberChecker
    {
        static List<int> listOfPrimeNumbers = new List<int>();

        public static int InputHandler(string input)
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
            else if (input == "clear")
            {
                return 4;
            }
            else if (int.TryParse(input, out int result))
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }

        public static bool inputNumberHandler(int inputNumber)
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
        public static string AddToList(int potentialPrimeNumber)
        {
            if (!listOfPrimeNumbers.Contains(potentialPrimeNumber) && inputNumberHandler(potentialPrimeNumber))
            {
                listOfPrimeNumbers.Add(potentialPrimeNumber);
                SortList();
                return potentialPrimeNumber + " added as a prime number\n";
            }
            else if (listOfPrimeNumbers.Contains(potentialPrimeNumber) && inputNumberHandler(potentialPrimeNumber))
            {
                return potentialPrimeNumber + " is a prime number, but is already stored";
            }
            else
            {
                return potentialPrimeNumber + " is not a prime number\n";
            }
        }

        public static void SortList()
        {
            if (listOfPrimeNumbers.Count() > 1)
            {
                for (int i = listOfPrimeNumbers.Count() - 1; i >= 0; i--)
                {
                    if (i > 0 && listOfPrimeNumbers[i] < listOfPrimeNumbers[i - 1])
                    {
                        int temp = listOfPrimeNumbers[i - 1];
                        listOfPrimeNumbers[i - 1] = listOfPrimeNumbers[i];
                        listOfPrimeNumbers[i] = temp;
                    }

                }
            }
        }

        public static void ClearList()
        {
            listOfPrimeNumbers = new List<int>();
        }

        public static List<int> ReturnListOfStoredPrimeNumbers()
        {
            return listOfPrimeNumbers;
        }
        public static int FindNextPrimeNumber(int highestStoredNumber)
        {
            highestStoredNumber++;
            if (inputNumberHandler(highestStoredNumber))
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
