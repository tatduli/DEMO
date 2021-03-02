using AutomatinioTestavimoMokymai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Test
{
    public class SeleniumInputTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            //Bet kuriam elementui laukiame 10s
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Iššokančiam langui laukiame kol jis pasirodys ir paspaudžiame ant X
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            wait.Until(item => popUp.Displayed);
            popUp.Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestSeleniumInputFirstBlock()
        {
            SeleniumInputPage page = new SeleniumInputPage(_driver);
            string myText = "Kaunas";
            page.InsertText(myText);
            page.clickMessageButton();
            page.checkResult(myText);

        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        public void TestSeleniumInputSecondBlock(string firstInput, string seconInput, string result)
        {
            SeleniumInputPage page = new SeleniumInputPage(_driver);
            page.InsertBothInputs(firstInput, seconInput);
            page.ClickSumButton();
            page.CheckSumResult(result);

        }


    }
}
