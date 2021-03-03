using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Page
{
    public class SeleniumCheckBoxPage: BasePage
    {
        private const string UrlAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private IWebElement _firstCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _textNearFirstOneCheckBox => Driver.FindElement(By.Id("txtAge"));
        IReadOnlyCollection<IWebElement> _multipleCheckBoxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _resultBox => Driver.FindElement(By.Id("check1"));

        public SeleniumCheckBoxPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Navigate().GoToUrl(UrlAddress);
        }

        public void CheckOneCheckBox()
        {
            if (!_firstCheckBox.Selected)
                _firstCheckBox.Click();
        }
        public void CheckResult(string expectedResult)
        {
            TestContext.Out.WriteLine(expectedResult);
            TestContext.Out.WriteLine(_textNearFirstOneCheckBox.Text);
            Assert.IsTrue(_textNearFirstOneCheckBox.Text.Equals(expectedResult));
        }

        public void UncheckOneCheckBox()
        {
            if (_firstCheckBox.Selected)
                _firstCheckBox.Click();
        }

        public void CheckMultipleCheckBox()
        {
            foreach (IWebElement element in _multipleCheckBoxList)
            {
                if (!element.Selected)
                    element.Click();
            }
        }

        public void UncheckMultipleCheckBox()
        {
            foreach (IWebElement element in _multipleCheckBoxList)
            {
                if (element.Selected)
                    element.Click();
            }
        }
        public void CheckMultipleBottonResult(string text)
        {
            var returnResult = ReturnValueFromResultBox();
            TestContext.Out.WriteLine(returnResult);
            //Thread.Sleep(5000);
            //Laukiame kol ant mygtuko paikeis tekstas iš Check į Uncheck
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(_resultBox, text));


            Assert.IsTrue(returnResult.Equals(text), "Somthing is wrong");
        }

        private string ReturnValueFromResultBox()
        {
            return _resultBox.GetAttribute("value");
        }
    }
}
