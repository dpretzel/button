using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace webform_test
{
    [TestClass]
    public class CashIn
    {
        //Once the user has at least 1 click and then clicks the Cash In button, their name should appear on the scoreboard.
        [TestMethod]
        public void Should_Cash_In_Using_Firefox()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://africkelbutton.azurewebsites.net/ButtonPage.aspx/");
                var nameBox = driver.FindElementById("txtName");
                DateTime serverTime = DateTime.Now;
                //var name = String.Concat("Selenium Test at ", serverTime.ToShortTimeString());
                var name = serverTime.ToLongTimeString();
                nameBox.SendKeys(name);
                var incBtn = driver.FindElementById("btnAdd");
                incBtn.Click();
                var cashInBtn = driver.FindElementById("btnUpload");
                cashInBtn.Click();
                var scoreboard = driver.FindElementById("gvScoreboard");
                var entryPath = String.Concat("//td[contains(text(), '", name, "')]");
                var boardEntry = driver.FindElementByXPath(entryPath);
                Assert.IsNotNull(boardEntry);
            }
        }
    }
}
