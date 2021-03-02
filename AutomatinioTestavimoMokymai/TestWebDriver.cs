using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    class TestWebDriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com";
            chrome.Close();
        }

        [Test]
        public static void TestFireFoxDriver()
        {
            IWebDriver forefox = new FirefoxDriver();
            forefox.Url = "https://login.yahoo.com";
            forefox.Close();
        }
        [Test]
        public static void TestYahooPage()
        {
            IWebDriver chrome = new FirefoxDriver();
            chrome.Url = "https://login.yahoo.com";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");
            IWebElement loginButton = chrome.FindElement(By.Id("login-signin"));
            loginButton.Click();
            chrome.Quit();
        }
        /// <summary>
        /// neveikė, nes popUp išokdavo
        /// </summary>
        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new FirefoxDriver(); // su Firefox praėjo
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Kaunas";
            inputField.SendKeys(myText);
            //su if reikėtų daryti
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();

            IWebElement findButton = chrome.FindElement(By.CssSelector("#get-input > button"));
            findButton.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.IsTrue(myText.Equals(result.Text), "no display text");
            //chrome.Quit();
        }

        //HW1
        [Test]
        //2+2
        public static void TestSeleniumTwoFieldTwoPlusTwo()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            int a = 2;
            inputField1.SendKeys(a.ToString());
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            int b = 2;
            inputField2.SendKeys(b.ToString());
            int sum = a + b;
            //su if reikėtų daryti
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();

            IWebElement botton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            botton.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sum.ToString(), result.Text, "Result must to be 4");
            chrome.Close();
        }

        [Test]
        //-5+3
        public static void TestSeleniumTwoField_FivePlusThree()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            int value1 = -5;
            inputField1.SendKeys(value1.ToString());
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            int value2 = 3;
            inputField2.SendKeys(value2.ToString());
            int sum = value1 + value2;
            //su if reikėtų daryti
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();

            IWebElement botton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            botton.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sum.ToString(), result.Text, "Result must to be -2");
            //chrome.Close();
        }

        [Test]
        //a+b
        public static void TestSeleniumTwoFieldAPlusB()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            string a = "a";
            inputField1.SendKeys(a);
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            string b = "b";
            inputField2.SendKeys(b);

            //su if reikėtų daryti
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();

            IWebElement botton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            botton.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "Result must to be NaN");
            //chrome.Close();
        }
    }
}
