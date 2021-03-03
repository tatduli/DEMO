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
        private static SeleniumCheckBoxPage _page;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            _page = new SeleniumCheckBoxPage(driver);

            //Bet kuriam elementui laukiame 10s
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        [Order(1)]
        [TestCase("Success - Check box is checked", TestName = "Check one check box")]

        public static void TestOneCheckBox(string text)
        {
            _page.CheckOneCheckBox();
            _page.CheckResult(text);
        }

        [Order(2)]
        [TestCase("Uncheck All", TestName = "Check all check box")]
        public static void TestsMultipleCheckBoxAllCheck(string text)
        {
            _page.UncheckOneCheckBox();
            _page.CheckMultipleCheckBox();
            TestContext.Out.WriteLine(text);
            _page.CheckMultipleBottonResult(text);
        }

        [Order(3)]
        [TestCase("Check All", TestName = "Uncheck all check box")]
        public static void TestsMultipleCheckBoxAllUncheck(string text)
        {
            _page.UncheckOneCheckBox();
            _page.UncheckMultipleCheckBox();
            _page.CheckMultipleBottonResult(text);
        }
    }
}
