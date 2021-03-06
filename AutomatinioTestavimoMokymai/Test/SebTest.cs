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
    public class SebTest
    {

        private static SebPage _page;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            _page = new SebPage(driver);

            //Bet kuriam elementui laukiame 10s
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //Iššokančiam langui laukiame kol jis pasirodys ir paspaudžiame ant X
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement popUp = driver.FindElement(By.Id("_reklama"));
            //wait.Until(item => popUp.Displayed);
            //popUp.Click();
            IWebElement cookies = driver.FindElement(By.CssSelector(".accept-selected > span"));
            wait.Until(item => cookies.Displayed);
            cookies.Click();

        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [TestCase("1000", "0", "Klaipėda", TestName = "Ar duos paskolą")]
        public static void TestArDuosPaskola(string pajamos, string isipareigojimai, string miestas)
        {
            _page.Pajamos(pajamos);
            _page.Isipareigojimais(isipareigojimai);
            _page.SelectFromByText(miestas);
            _page.VerifyResult();

        }

    }
}
