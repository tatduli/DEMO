using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    //testuojmas puslapis 
    //https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent
    // su skirtingomis naršyklėmis

    class HW2_1
    {
        private static IWebDriver _driver;

        [TearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            Opera
        }

        public static IWebDriver WebDriver(BrowserType type)
        {
            IWebDriver driver = null;

            switch (type)
            {

                case BrowserType.Firefox:
                    driver = new FirefoxDriver();

                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();

                    break;
                default:
                    driver = new OperaDriver();

                    break;
            }

            return driver;
        }

        [TestCase(BrowserType.Chrome, "Chrome", TestName = "Chrome")]
        [TestCase(BrowserType.Firefox, "Firefox", TestName = "Forefox")]

        public static void TestTextInBrowser(BrowserType browser, string text)
        {
            TestContext.Out.WriteLine($"žiūriu koks ateina tekstas {text}");
            TestContext.Out.WriteLine($"žiūriu kokia ateina naršyklė {browser}");
            _driver = WebDriver(browser);
            Setup();
            string textOnPage = _driver.FindElement(By.CssSelector(".simple-major")).Text.ToLower();
            TestContext.Out.WriteLine($"žiūriu koks tekstas puslayje {textOnPage}");
            Assert.IsTrue(textOnPage.Contains(text.ToLower()), "No text");
        }

        //[OneTimeSetUp]
        public static void Setup()
        {
            //TestContext.Out.WriteLine(_driver);
            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

    }
}
