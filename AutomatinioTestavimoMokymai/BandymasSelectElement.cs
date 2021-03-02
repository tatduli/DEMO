using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    class BandymasSelectElement
    {
        private static IWebDriver driver;

        [Test]

        public void bb()
        {

            driver = new ChromeDriver();
            driver.Url = "http://demos.dojotoolkit.org/dijit/tests/test_Menu.html";
            IWebElement element = driver.FindElement(By.XPath("//select[@aria-label='select']"));
            SelectElement select_elem = new SelectElement(element);

            /* Sleep for 4 seconds after page is displayed */
            System.Threading.Thread.Sleep(4000);

            select_elem.SelectByText("on IE6");
        }

    }
}
