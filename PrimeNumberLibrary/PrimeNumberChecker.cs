using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberLibrary
{
    public class PrimeNumberChecker
    {
        private static List<int> listOfPrimeNumbers = new List<int>();

        //Takes an input from the console, checks if it's null or not, returns 7 if null and returns
        //1 if input is "stop", 2 if input is "print", 3 if input is "next", 4 if input is "clear",
        //5 if input is a valid integer or 6 if the input is an invalid command or not a valid integer
        public static int InputHandler(string input)
        {
            if (input != null)
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
                //Tries to parse the input, if the result is true then it's a valid number
                // and the program returns the value that indicates that it's a valid number
                else if (int.TryParse(input, out int result))
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
            }
            else
            {
                return 7;
            }
        }

        //takes an integer and returns true or false based on if it's a prime number or not
        //https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number/15743238
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

        //takes a potential number to check, if the number isn't already stored and if it's a primer number it is added to the list,
        //if the number is already in the the list it returns a string that indicates that it is already stored
        //and if it's not a prime number it returns this information to the user
        public static string AddToList(int potentialPrimeNumber)
        {
            bool ifListContainsNumber = listOfPrimeNumbers.Contains(potentialPrimeNumber);
            bool ifNumberIsAPrimeNumber = inputNumberHandler(potentialPrimeNumber);
            if (!ifListContainsNumber && ifNumberIsAPrimeNumber)
            {
                listOfPrimeNumbers.Add(potentialPrimeNumber);
                SortList();
                return potentialPrimeNumber + " added as a prime number\n";
            }
            else if (ifListContainsNumber && ifNumberIsAPrimeNumber)
            {
                return potentialPrimeNumber + " is a prime number, but is already stored";
            }
            else
            {
                return potentialPrimeNumber + " is not a prime number\n";
            }
        }

        //called whenever a number is added to the list and then sorts it so the largest number is always
        //at the last position in the list
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

        //clears the current list by overwriting the old list with a new one
        public static void ClearList()
        {
            listOfPrimeNumbers = new List<int>();
        }

        //returns the list of stored values
        public static List<int> ReturnListOfStoredPrimeNumbers()
        {
            return listOfPrimeNumbers;
        }
        //takes the highest value in the list, increments it by 1, checks if it's a prime number.
        //if it is a prime number it returns this number so it can be stored in the list,
        // else it returns the same method with the incremented value until a prime number is found
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
