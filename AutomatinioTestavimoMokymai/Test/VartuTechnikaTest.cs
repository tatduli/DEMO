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
    class VartuTechnikaTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://vartutechnika.lt/");
            //Bet kuriam elementui laukiame 10s
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("2000", "2000", true, false, "665.98", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000 X 2000 = 692.35")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]

        public void TestVartuTechnika(string width, string high,
                                      bool auto, bool work, string result)
        {
            VartuTechnikaPage page = new VartuTechnikaPage(_driver);
            page.InsertHighAndWith(width, high)
                .CheckBoxAuto(auto)
                .CheckBoxWork(work)
                .ClickCalculateButton()
                .CheckResult(result);
        }
    }
}
