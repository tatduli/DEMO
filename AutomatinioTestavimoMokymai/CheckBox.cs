using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    //1.Pažymime “Click on this check box” , patikriname kad atsirado “Success - Check
    //box is checked” pranešimas
    //2. Pažymime visas “Multiple Checkbox Demo” sekcijos varneles, patikriname kad
    //mygtukas persivadino į “Uncheck All”
    //3. Paspaudžiame mygtuką “Uncheck All” , patikriname kad visos “Multiple Checkbox
    //Demo” sekcijos varneles atžymėtos


    class CheckBox
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            //_driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html"; galima kitaip
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");

            _driver.Manage().Window.Maximize();


        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestOneCheckBox()
        {
            _driver.FindElement(By.Id("isAgeSelected")).Click();
            IWebElement text = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(text.Text.Equals("Success - Check box is checked"));
        }

        [Test]
        public static void TestListCheckBox()
        {
            IWebElement firstCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (firstCheckBox.Selected)
                firstCheckBox.Click();

            IReadOnlyCollection<IWebElement> multipleCheckBoxList = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement element in multipleCheckBoxList)
            {
                element.Click();
            }
            //getAtribute

        }

        private static void IReadOnlyCollection<T>()
        {
            throw new NotImplementedException();
        }
    }
}
