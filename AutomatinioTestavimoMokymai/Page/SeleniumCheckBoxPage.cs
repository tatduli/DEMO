using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Page
{
    public class SeleniumCheckBoxPage : BasePage
    {
        private static IWebDriver _driver;
        private IWebElement _selectedElement => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _textNearFirstOneCheckBox = _driver.FindElement(By.Id("txtAge"));

        public SeleniumCheckBoxPage(IWebDriver webDriver) : base(webDriver) { }

        public void CheckOneCheckBox(bool OneCheckBox)
        {         
                if (OneCheckBox != _textNearFirstOneCheckBox.Selected)
                _textNearFirstOneCheckBox.Click();                                      
        }
        public void CheckResult(string expectedResult)
        {
            Assert.IsTrue(_textNearFirstOneCheckBox.Text.Equals(expectedResult));
        }
    }
}
