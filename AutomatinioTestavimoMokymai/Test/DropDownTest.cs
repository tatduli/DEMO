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
    public class DropDownTest : BaseTest
    {
                        
        [Test]
        public void TestDropDown()
        {
            dropdownPage.SelectFromByText("Friday");
            dropdownPage.VerifyResult("Friday");
        }

     
        [TestCase("Texas,Ohio", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
        [TestCase("Texas,California,Ohio,Washington", TestName = "Pasirenkame 4 reiksmes ir patikriname pirma pasirinkima")]//neiveikia su paskutiniu
        public void TestFirstSelectedBotton(string states)
        {
            dropdownPage.UnselectedAllMultipleDropdown();
            List<string> state = states.Split(',').ToList();
            dropdownPage.SelectedMultipleDropdownAndChlickFirstBotton(state);
            dropdownPage.CheckFirstState(state[0]);
        }
        //neveikia

        [TestCase("Texas,Ohio", TestName = "Pasirenkame 2 reiksmes ir patikriname ar visos atspasdintos")]
        [TestCase("Washington,California,Texas,Ohio", TestName = "Pasirenkame 4 reiksmes ir patikriname ar visos atspasdintos")]
        public void TestGetAllSelectedBotton(string states)
        {
            dropdownPage.NavigateToDefaultPage();
            dropdownPage.UnselectedAllMultipleDropdown();
            List<string> state = states.Split(',').ToList();
            dropdownPage.SelectFromMultipleDropdownByValue(state);
            dropdownPage.ClickGetAllButton();
            dropdownPage.CheckAllState(state.ToString());
            
        }
    }
}
