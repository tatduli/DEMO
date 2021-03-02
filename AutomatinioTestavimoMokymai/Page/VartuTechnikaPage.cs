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
    class VartuTechnikaPage: BasePage
    {
        private static IWebDriver _driver;
        private IWebElement _inputField1 => _driver.FindElement(By.Id("doors_width"));
        private IWebElement _inputField2 => _driver.FindElement(By.Id("doors_height"));
        private IWebElement _checkAuto => _driver.FindElement(By.Id("automatika"));
        private IWebElement _checkWork => _driver.FindElement(By.Id("darbai"));
        private IWebElement _botton => _driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultFromPage => _driver.FindElement(By.CssSelector("#calc_result > div"));
        public VartuTechnikaPage(IWebDriver webDriver) : base(webDriver) { }

        public VartuTechnikaPage InsertWidth(string width)
        {
            _inputField1.Clear();
            _inputField1.SendKeys(width);
            return this;
        }
        public VartuTechnikaPage InsertHigh(string high)
        {
            _inputField2.Clear();
            _inputField2.SendKeys(high);
            return this;
        }

        public VartuTechnikaPage InsertHighAndWith(string width, string high)
        {
            InsertWidth(width);
            TestContext.Out.WriteLine(width);
            InsertHigh(high);
            TestContext.Out.WriteLine(high);
            return this;
        }

        public VartuTechnikaPage CheckBoxAuto(bool auto)
        {
            if (auto != _checkAuto.Selected)
                _checkAuto.Click();
            return this;
        }

        public VartuTechnikaPage CheckBoxWork(bool work)
        {
            if (work != _checkWork.Selected)
                _checkWork.Click();
            return this;
        }

        public VartuTechnikaPage ClickCalculateButton()
        {
            _botton.Click();
            return this;
        }
        public void CheckResult(string expectedResult)
        {
            WaitForResult();
            TestContext.Out.WriteLine(expectedResult);
            TestContext.Out.WriteLine(_resultFromPage.Text);
            Assert.IsTrue(_resultFromPage.Text.Contains(expectedResult), $"Result is not the same, expented {expectedResult}, but was {_resultFromPage.Text}");
        }
        private VartuTechnikaPage WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _resultFromPage.Displayed);
            return this;
        }
    }
}
