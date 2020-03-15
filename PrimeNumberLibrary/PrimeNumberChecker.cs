using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberLibrary
{
    public class PrimeNumberChecker
    {
        private static List<int> listOfPrimeNumbers = new List<int>();
        public static bool loopBoolean = true;

        //Takes an input from the console, checks if it's null or not, returns a message related to each input
        public static string InputHandler(string userInputFromConsole)
        {
            if (userInputFromConsole != null)
            {
                userInputFromConsole = userInputFromConsole.ToLower();
                if (userInputFromConsole == "stop")
                {
                    loopBoolean = false;
                    return "Program stopped";
                }
                else if (userInputFromConsole == "print")
                {
                    if (ReturnListOfStoredPrimeNumbers().Count > 0)
                    {
                        foreach (var storedNumbers in ReturnListOfStoredPrimeNumbers())
                        {
                            Console.WriteLine(storedNumbers);
                        }
                        return "\n";
                    }
                    else
                    {
                        return "No stored numbers to print\n";
                    }
                }
                else if (userInputFromConsole == "next")
                {
                    if (ReturnListOfStoredPrimeNumbers().Count() > 0)
                    {
                        int nextPrimeNumber = FindNextPrimeNumber(ReturnListOfStoredPrimeNumbers()[ReturnListOfStoredPrimeNumbers().Count() - 1]);
                        AddToList(nextPrimeNumber);
                        return nextPrimeNumber + " added as the next prime number\n";
                    }
                    else
                    {
                        return "No stored prime numbers to compare\n";
                    }
                }
                else if (userInputFromConsole == "clear")
                {
                    ClearList();
                    return "Cleared the list of stored prime numbers\n";
                }
                //Tries to parse the input, if the result is true then it's a valid number
                // and the program returns the value based on if it's a prime number or not
                else if (int.TryParse(userInputFromConsole, out int result))
                {
                    return AddToList(result);
                }
                else
                {
                    return "\"" + userInputFromConsole + "\" is not a proper command or a number\n";
                }
            }
            else
            {
                return "Input cannot be null";
            }
        }

        //takes an integer and returns true or false based on if it's a prime number or not
        //https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number/15743238
        public static bool InputNumberHandler(int inputNumber)
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

        //takes a potential number to check, if the number isn't already stored and if it's a prime number it is added to the list,
        //if the number is already in the the list it returns a string that indicates that it is already stored
        //and if it's not a prime number it returns this information to the user
        public static string AddToList(int potentialPrimeNumber)
        {
            bool ifListContainsNumber = listOfPrimeNumbers.Contains(potentialPrimeNumber);
            bool ifNumberIsAPrimeNumber = InputNumberHandler(potentialPrimeNumber);
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
        //else it returns the same method with the incremented value until a prime number is found
        public static int FindNextPrimeNumber(int highestStoredNumber)
        {
            highestStoredNumber++;
            if (InputNumberHandler(highestStoredNumber))
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
