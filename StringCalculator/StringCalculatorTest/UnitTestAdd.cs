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

        [TestMethod]
        public void TestAddMultipleNumbers()
        {
            StringCalculator.Service.StringCalculatorService Test = new Service.StringCalculatorService();
            res = Test.Add("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(res, 78);
        }
    }
}
