using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberLibrary
{
    public class PrimeNumberChecker
    {
        private static List<int> listOfPrimeNumbers = new List<int>();
        public static bool loopBoolean = true;

        public static void InputHandler(string input)
        {
            if (input != null)
            {
                input = input.ToLower();
                if (input == "stop")
                {
                    loopBoolean = false;
                }
                else if (input == "print")
                {
                    if (ReturnListOfStoredPrimeNumbers().Count > 0)
                    {
                        foreach (var storedNumbers in ReturnListOfStoredPrimeNumbers())
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
                else if (input == "next")
                {
                    if (ReturnListOfStoredPrimeNumbers().Count() > 0)
                    {
                        int nextPrimeNumber = FindNextPrimeNumber(ReturnListOfStoredPrimeNumbers()[ReturnListOfStoredPrimeNumbers().Count() - 1]);
                        AddToList(nextPrimeNumber);
                        Console.WriteLine(nextPrimeNumber + " added as the next prime number\n");
                    }
                    else
                    {
                        Console.WriteLine("No stored prime numbers to compare\n");
                    }
                }
                else if (input == "clear")
                {
                    ClearList();
                    Console.WriteLine("Cleared the list of stored prime numbers\n");
                }
                else if (int.TryParse(input, out int result))
                {
                    Console.WriteLine(PrimeNumberChecker.AddToList(result));
                }
                else
                {
                    Console.WriteLine("\"" + input + "\" is not a proper command or a number\n");
                }
            }
            else {
                Console.WriteLine("The input value cannot be null");
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
