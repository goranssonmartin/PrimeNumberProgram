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
            Assert.AreEqual(1, PrimeNumberChecker.ConsoleHandler("stop"));
        }

        [Test]
        public void Test_IfPrintInputReturns2()
        {
            Assert.AreEqual(2, PrimeNumberChecker.ConsoleHandler("print"));
        }

        [Test]
        public void Test_IfNextInputReturns3()
        {
            Assert.AreEqual(3, PrimeNumberChecker.ConsoleHandler("next"));
        }

        [Test]
        public void Test_IfANumberInputReturns4()
        {
            Assert.AreEqual(4, PrimeNumberChecker.ConsoleHandler("21"));
        }

        [Test]
        public void Test_IfInvalidInputReturns5()
        {
            Assert.AreEqual(5, PrimeNumberChecker.ConsoleHandler("katt"));
        }

        [Test]
        public void Test_IfPrimeNumberReturnsTrue()
        {
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(2));
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(5));
            Assert.AreEqual(true, PrimeNumberChecker.HandleInputNumber(11));
        }

        [Test]
        public void Test_IfNonPrimeNumberReturnsFalse()
        {
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(1));
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(4));
            Assert.AreEqual(false, PrimeNumberChecker.HandleInputNumber(321));
        }

        [Test]
        //whut du heck
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
            Assert.AreEqual(13, PrimeNumberChecker.FindNextPrimeNumber(PrimeNumberChecker.ReturnListOfStoredPrimeNumbers().Max()));
        }



    }
}