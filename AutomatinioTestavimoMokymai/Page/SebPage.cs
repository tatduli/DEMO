
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

        
        public void FocusOnFrame()
        {
            Driver.SwitchTo().Frame(0);
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

        public void ChlickOnResultBotton()
        {
            _calculateButton.Click();
        }
        public void VerifyResult(int norimaPaskola)
        {
            int result = Convert.ToInt32(_resultField.Text.Replace(" ",""));           
           // var resultSum = Regex.Match(text, @"\d+").Value;
            Console.WriteLine(result);
            Assert.GreaterOrEqual(result, norimaPaskola, $"Result is wrong, not {result}");
        }
    }
}
