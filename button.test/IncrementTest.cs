using System;
using @class_test;
using @button;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace button_test
{
    [TestClass]
    public class IncrementTest
    {
        [TestMethod]
        public void Test_Click()
        {
            int expected = 5;
            
            int actual = TestClass.returnFive();
            ButtonPage.testy();

            Assert.AreEqual(expected, actual);
        }
    }
}
