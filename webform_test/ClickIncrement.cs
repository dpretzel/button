using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace webform_test
{
    [TestClass]
    public class ClickIncrement
    {
        //When the user clicks the Increment button for the first time, the 0 should become a 1.
        [TestMethod]
        public void Should_Click_Increment_Using_Firefox()
        {
            using (var driver = new FirefoxDriver())
            {
                var expected = "1";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://africkelbutton.azurewebsites.net/ButtonPage.aspx/");
                var incBtnBefore = driver.FindElementById("btnAdd");
                incBtnBefore.Click();
                var incBtnAfter = driver.FindElementById("btnAdd");
                var actual = incBtnAfter.GetAttribute("Value");
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
