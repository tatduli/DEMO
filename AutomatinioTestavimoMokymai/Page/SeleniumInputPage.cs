using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Page
{
    public class SeleniumInputPage
    {
        private static IWebDriver _driver;
        private IWebElement _inputField => _driver.FindElement(By.Id("user-message"));
        private IWebElement _findButton => _driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement _result => _driver.FindElement(By.Id("display"));
        private IWebElement _inputField1 => _driver.FindElement(By.Id("sum1"));
        private IWebElement _inputField2 => _driver.FindElement(By.Id("sum2"));
        private IWebElement _botton => _driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement resultFromPage => _driver.FindElement(By.Id("displayvalue"));

        public SeleniumInputPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
        public void InsertText(string text)
        {
            _inputField.Clear();
            _inputField.SendKeys(text);
        }

        public void clickMessageButton()
        {
            _findButton.Click();
        }

        public void checkResult(string expectedResult)
        {
            Assert.IsTrue(expectedResult.Equals(_result.Text), "no display text");
        }

        public void InsertFirstInput(string text)
        {
            _inputField1.Clear();
            _inputField1.SendKeys(text);
        }

        public void InsertSecondInput(string text)
        {
            _inputField2.Clear();
            _inputField2.SendKeys(text);
        }
        public void InsertBothInputs(string first, string second)
        {
            InsertFirstInput(first);
            InsertSecondInput(second);
        }

        public void ClickSumButton()
        {
            _botton.Click();
        }

        public void CheckSumResult(string expectedResultSum)
        {
            Assert.AreEqual(expectedResultSum, resultFromPage.Text, "Result not OK");
        }


    }
}
