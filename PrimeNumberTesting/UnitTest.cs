using NUnit.Framework;
using PrimeNumberLibrary;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberTesting
{
    public class Tests
    {
        [Test]
        public void Test_IfDifferenetInputsReturnsTheExpectedValues() {
            Assert.AreEqual("Program stopped", PrimeNumberChecker.InputHandler("StoP"));
            Assert.AreEqual("No stored numbers to print\n", PrimeNumberChecker.InputHandler("priNT"));
            Assert.AreEqual("No stored prime numbers to compare\n", PrimeNumberChecker.InputHandler("nEXt"));
            Assert.AreEqual("Cleared the list of stored prime numbers\n", PrimeNumberChecker.InputHandler("clEAr"));
            Assert.AreEqual("21 is not a prime number\n", PrimeNumberChecker.InputHandler("21"));
            Assert.AreEqual("Input cannot be null", PrimeNumberChecker.InputHandler(null));
            Assert.AreEqual("\"katt\" is not a proper command or a number\n", PrimeNumberChecker.InputHandler("katt"));
        }

        [Test]
        public void Test_IfPrimeNumberReturnsCorrectValue()
        {
            Assert.AreEqual(true, PrimeNumberChecker.InputNumberHandler(2));
            Assert.AreEqual(true, PrimeNumberChecker.InputNumberHandler(5));
            Assert.AreEqual(true, PrimeNumberChecker.InputNumberHandler(11));
            Assert.AreEqual(false, PrimeNumberChecker.InputNumberHandler(1234567));
            Assert.AreEqual(false, PrimeNumberChecker.InputNumberHandler(4));
            Assert.AreEqual(false, PrimeNumberChecker.InputNumberHandler(21));
            Assert.AreEqual(false, PrimeNumberChecker.InputNumberHandler(-21));
        }

        [Test]
        public void Test_IfAddingMultipleNumbersCreatesExpectedList()
        {
            List<int> expectedList = new List<int>();
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(11);
            for (int i = 0; i < 13; i++)
            {
                PrimeNumberChecker.AddToList(i);
            }

            Assert.AreEqual(expectedList, PrimeNumberChecker.ReturnListOfStoredPrimeNumbers());
        }

        [Test]
        public void Test_IfListSortsItselfAfterAddingPrimeNumber()
        {
            List<int> expectedList = new List<int>();
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(11);
            PrimeNumberChecker.AddToList(11);
            PrimeNumberChecker.AddToList(7);
            PrimeNumberChecker.AddToList(2);
            PrimeNumberChecker.AddToList(5);
            PrimeNumberChecker.AddToList(3);

            Assert.AreEqual(expectedList, PrimeNumberChecker.ReturnListOfStoredPrimeNumbers());
        }

        [Test]
        public void Test_IfClearingAListWorks()
        {
            List<int> expectedList = new List<int>();
            PrimeNumberChecker.AddToList(11);
            PrimeNumberChecker.AddToList(7);
            PrimeNumberChecker.AddToList(2);
            PrimeNumberChecker.AddToList(5);
            PrimeNumberChecker.AddToList(3);
            PrimeNumberChecker.ClearList();

            Assert.AreEqual(expectedList, PrimeNumberChecker.ReturnListOfStoredPrimeNumbers());
        }

        [Test]
        public void Test_IfNextIsWorkingAsIntended()
        {
            PrimeNumberChecker.AddToList(11);
            PrimeNumberChecker.AddToList(7);
            PrimeNumberChecker.AddToList(2);
            int highestStoredValue = PrimeNumberChecker.ReturnListOfStoredPrimeNumbers()[PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() - 1];
            Assert.AreEqual(13, PrimeNumberChecker.FindNextPrimeNumber(highestStoredValue));
        }
    }
}