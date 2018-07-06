using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace webform_test
{
    [TestClass]
    public class Deny0Clicks
    {
        //Don't allow the Cash In button to be clicked unless the user has clicked at least 1 time.
        [TestMethod]
        public void Should_Disable_0_Click_Cash_In_Using_Firefox()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://africkelbutton.azurewebsites.net/ButtonPage.aspx/");
                var cashInBtn = driver.FindElementById("btnUpload");
                var try1 = cashInBtn.Enabled;
                var incBtn = driver.FindElementById("btnAdd");
                incBtn.Click();
                cashInBtn = driver.FindElementById("btnUpload");
                var try2 = cashInBtn.Enabled;
                var success = !try1 && try2;
                Assert.IsTrue(success);
            }
        }
    }
}
