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
            Assert.AreEqual(1, PrimeNumberChecker.InputHandler("StoP"));
            Assert.AreEqual(2, PrimeNumberChecker.InputHandler("priNT"));
            Assert.AreEqual(3, PrimeNumberChecker.InputHandler("nEXt"));
            Assert.AreEqual(4, PrimeNumberChecker.InputHandler("clEAr"));
            Assert.AreEqual(5, PrimeNumberChecker.InputHandler("21"));
            Assert.AreEqual(7, PrimeNumberChecker.InputHandler(null));
            Assert.AreEqual(6, PrimeNumberChecker.InputHandler("katt"));
        }

        [Test]
        public void Test_IfPrimeNumberReturnsCorrectValue()
        {
            Assert.AreEqual(true, PrimeNumberChecker.inputNumberHandler(2));
            Assert.AreEqual(true, PrimeNumberChecker.inputNumberHandler(5));
            Assert.AreEqual(true, PrimeNumberChecker.inputNumberHandler(11));
            Assert.AreEqual(false, PrimeNumberChecker.inputNumberHandler(1234567));
            Assert.AreEqual(false, PrimeNumberChecker.inputNumberHandler(4));
            Assert.AreEqual(false, PrimeNumberChecker.inputNumberHandler(21));
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
            int highestStoredValue = PrimeNumberChecker.ReturnListOfStoredPrimeNumbers()[PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() - 1];
            Assert.AreEqual(13, PrimeNumberChecker.FindNextPrimeNumber(highestStoredValue));
        }
    }
}