
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace AutomatinioTestavimoMokymai.Page
{
    public class SebPage : BasePage
    {
        private const string UrlAddress = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";
      
        private IWebElement _seimosPajamosAtskaiciusMokescius => Driver.FindElement(By.Id("income"));       
        private IWebElement _seimosFinansiniaiIsipareigojimai => Driver.FindElement(By.Id("commitments"));
        private IWebElement _calculateButton => Driver.FindElement(By.CssSelector("#calculate > span"));
        private SelectElement _cityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        private IWebElement _resultField => Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > span > strong"));
        private IWebElement _reklama => Driver.FindElement(By.Id("seb-bot-closeIcn"));

        public SebPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Navigate().GoToUrl(UrlAddress);
        }

        


        public void Pajamos(string income)
        {           
            _seimosPajamosAtskaiciusMokescius.Clear();
            _seimosPajamosAtskaiciusMokescius.Click();
            _seimosPajamosAtskaiciusMokescius.SendKeys(income);
        }

        public void Isipareigojimais(string income)
        {
            _seimosFinansiniaiIsipareigojimai.Clear();
            _seimosFinansiniaiIsipareigojimai.Click();
            _seimosFinansiniaiIsipareigojimai.SendKeys(income);
        }

        public void SelectFromByText(string text)
        {
            _cityDropdown.SelectByText(text);            
        }

        public void VerifyResult()
        {
            string text = _resultField.Text;
            Console.WriteLine(_resultField.Text);
            var resultSum = Regex.Match(text, @"\d+").Value;
            Console.WriteLine(resultSum);
            //Assert.GreaterOrEqual(), $"Result is wrong, not {selectedDay}");
        }
    }
}
