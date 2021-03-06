

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutomatinioTestavimoMokymai.Page
{
    public class DropDownPage : BasePage
    {
        
        private const string UrlAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private SelectElement _dropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        //su klaviatura paspaudimas
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _rezultText => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement _firstSelectedBotton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedBotton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _getOptionSelectedResult => Driver.FindElement(By.CssSelector(".getall-selected"));

       
        public DropDownPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Navigate().GoToUrl(UrlAddress);
        }

        public DropDownPage SelectFromByText(string text)
        {
            _dropDown.SelectByText(text);
            return this;
        }

        public DropDownPage selectFromByValue(string text)
        {
            _dropDown.SelectByValue(text);
            return this;
        }

        public void VerifyResult(string selectedDay)
        {
            Assert.IsTrue(_rezultText.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
        }


        public void UnselectedAllMultipleDropdown()
        {
            _multiDropDown.DeselectAll();
        }

        public void ClickGetAllButton()
        {
            _getAllSelectedBotton.Click();            
        }
        public void SelectedMultipleDropdownAndChlickFirstBotton(List<string> text)
        {          
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);// paspaudžiu ctrl
            IList<IWebElement> optionsList = _multiDropDown.Options;
           
            for (int i = 0; i < text.Count; i++)            
            {
                for (int j = 0; j < optionsList.Count; j++)
                {
                    IWebElement state = optionsList[j];
                    if (state.GetAttribute("value").Equals(text[i]))
                    {
                        Console.WriteLine("blabla");
                        action.Click(state);
                        //state.Click();                        
                        Console.WriteLine(state.Text);
                        break;
                    }
                }                                         
            }

            action.KeyUp(Keys.Control);
            action.Build().Perform();

            action.Click(_firstSelectedBotton);
            action.Build().Perform();
        }

        public void SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            _multiDropDown.DeselectAll();
            foreach (IWebElement option in _multiDropDown.Options)
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    ClickMultipleBox(option);
                }
            
        }

        public void CheckFirstState(string selectedElement)
        {
            string result = _getOptionSelectedResult.Text;            
            Assert.IsTrue(result.Contains(selectedElement),
                          $"{ selectedElement} is missing. {result}");
        }

        public void CheckAllState(string selectedElement)
        {
            string result = _getOptionSelectedResult.Text;
            foreach(var element in selectedElement)
            {
                Assert.IsTrue(result.Contains(selectedElement),
                         $"Shoud be {selectedElement}, but was. {result}");
            }
            
            
        }
        private void ClickMultipleBox(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
    }
}
