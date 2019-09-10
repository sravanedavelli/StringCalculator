using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class StringCalculatorTest
    {
        int res = 0;

        [TestMethod]
        public void TestAddTwoNumbers()
        {
            
            StringCalculator.Service.StringCalculatorService Test = new Service.StringCalculatorService();
            res = Test.Add("1,2");
            Assert.AreEqual(res,3);
        }

        [TestMethod]
        public void TestAddEmpty()
        {
            StringCalculator.Service.StringCalculatorService Test = new Service.StringCalculatorService();
            res = Test.Add(" ");
            Assert.AreEqual(res,0);
        }

        [TestMethod]
        public void TestAddStringAndNumber()
        {
            StringCalculator.Service.StringCalculatorService Test = new Service.StringCalculatorService();
            res = Test.Add("3,hagsdfgsdf");
            Assert.AreEqual(res,3);
        }
    }
}
