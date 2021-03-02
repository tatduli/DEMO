using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    class VartuTechnika
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            //_driver.Url = "http://vartutechnika.lt/"; galima kitaip
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


        public static void TestVartuTechnika(string width, string high,
                                             bool auto, bool work, string result)
        {


            IWebElement inputField1 = _driver.FindElement(By.Id("doors_width"));
            inputField1.Clear();
            inputField1.SendKeys(width);
            IWebElement inputField2 = _driver.FindElement(By.Id("doors_height"));
            inputField2.Clear();
            inputField2.SendKeys(high);
            IWebElement checkAuto = _driver.FindElement(By.Id("automatika"));

            if (auto != checkAuto.Selected)
                checkAuto.Click();
            IWebElement checkWork = _driver.FindElement(By.Id("darbai"));
            if (work != checkWork.Selected)
                checkWork.Click();
            IWebElement botton = _driver.FindElement(By.Id("calc_submit"));
            botton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#calc_result > div")).Displayed);
            IWebElement resultFromPage = _driver.FindElement(By.CssSelector("#calc_result > div"));
            //Assert.AreEqual(result, resultFromPage.Text.Contains(result), $"Result is not the same, expected {result}, but was {resultFromPage.Text}");
            Assert.IsTrue(resultFromPage.Text.Contains(result), $"Result is not the same, expented {result}, but was {resultFromPage.Text}");
        }
    }
}
