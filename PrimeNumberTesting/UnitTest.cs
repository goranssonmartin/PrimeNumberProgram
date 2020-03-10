using NUnit.Framework;
using PrimeNumberLibrary;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumberTesting
{
    public class Tests
    {
        [Test]
        public void Test_IfStopInputReturns1()
        {
            Assert.AreEqual(1, PrimeNumberChecker.ConsoleHandler("StoP"));
        }

        [Test]
        public void Test_IfPrintInputReturns2()
        {
            Assert.AreEqual(2, PrimeNumberChecker.ConsoleHandler("priNT"));
        }

        [Test]
        public void Test_IfNextInputReturns3()
        {
            Assert.AreEqual(3, PrimeNumberChecker.ConsoleHandler("nEXt"));
        }

        [Test]
        public void Test_IfAClearInputReturns4()
        {
            Assert.AreEqual(4, PrimeNumberChecker.ConsoleHandler("clEAr"));
        }

        [Test]
        public void Test_IfANumberInputReturns5()
        {
            Assert.AreEqual(5, PrimeNumberChecker.ConsoleHandler("21"));
        }

        [Test]
        public void Test_IfInvalidInputReturns6()
        {
            Assert.AreEqual(6, PrimeNumberChecker.ConsoleHandler("katt"));
        }

        [Test]
        public void Test_IfPrimeNumberReturnsCorrectValue()
        {
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(2));
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(5));
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(11));
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(1234567));
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(4));
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(21));
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
        public void Test_IfNextIsWorkingAsIntended()
        {
            PrimeNumberChecker.AddToList(11);
            int highestStoredValue = PrimeNumberChecker.ReturnListOfStoredPrimeNumbers()[PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Count() - 1];
            Assert.AreEqual(13, PrimeNumberChecker.FindNextPrimeNumber(highestStoredValue));
        }
    }
}