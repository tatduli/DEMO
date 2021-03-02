using AutomatinioTestavimoMokymai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Test
{
    public class SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            //Bet kuriam elementui laukiame 10s
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            //_driver.FindElement(By.Id("cookiescript_reject")).Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
        [TestCase(false, "Success - Check box is checked", TestName = "Check one check box")]


        public static void TestOneCheckBox(bool check, string text)
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            page.CheckOneCheckBox(check);
            page.CheckResult(text);
        }
    }
}
