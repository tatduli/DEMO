using AutomatinioTestavimoMokymai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Test
{
    public class DropDownTest
    {
        private static DropDownPage _page;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            _page = new DropDownPage(driver);

            //Bet kuriam elementui laukiame 10s
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            // _page.CloseBrowser();
        }

        [Test]
        public void TestDropDown()
        {
            _page.SelectFromByText("Friday");
            _page.VerifyResult("Friday");
        }

     
        [TestCase("Texas,Ohio", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
        [TestCase("Washington,California,Texas,Ohio", TestName = "Pasirenkame 4 reiksmes ir patikriname pirma pasirinkima")]//neiveikia 
        public void TestFirstSelectedBotton(string states)
        {           
            _page.UnselectedAllMultipleDropdown();
            List<string> state = states.Split(',').ToList(); 
            _page.SelectedMultipleDropdownAndChlickFirstBotton(state);            
            _page.CheckFirstState(state[0]);
        }

        [TestCase("Texas,Ohio", TestName = "Pasirenkame 2 reiksmes ir patikriname ar visos atspasdintos")]
        [TestCase("Washington,California,Texas,Ohio", TestName = "Pasirenkame 4 reiksmes ir patikriname ar visos atspasdintos")]
        public void TestGetAllSelectedBotton(string states)
        {
            _page.UnselectedAllMultipleDropdown();
            List<string> state = states.Split(',').ToList();
            _page.SelectFromMultipleDropdownByValue(state);
            _page.ClickGetAllButton();
            _page.CheckAllState(state.ToString());
            
        }
    }
}
