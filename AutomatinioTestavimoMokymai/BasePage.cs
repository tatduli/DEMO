using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();

        }
    }
}
