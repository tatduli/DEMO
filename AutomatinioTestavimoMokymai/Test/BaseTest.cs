using AutomatinioTestavimoMokymai.Driver;
using AutomatinioTestavimoMokymai.Page;
using AutomatinioTestavimoMokymai.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Test
{
    
        public class BaseTest
        {
            public static IWebDriver driver;
            public static DropDownPage dropdownPage;
            public static SebPage sebPage;
            public static VartuTechnikaPage vartuTechnikaPage;
           // public static SenukaiPage _senukaiPage;
           // public static AlertPage _alertPage;


            [OneTimeSetUp]
            public static void SetUp()
            {
                driver = CustomDriver.GetChromeDriver();
                dropdownPage = new DropDownPage(driver);
                sebPage = new SebPage(driver);
                vartuTechnikaPage = new VartuTechnikaPage(driver);
                //_senukaiPage = new SenukaiPage(driver);
                //_alertPage = new AlertPage(driver);
            }

            [TearDown]
            public static void TakeScreenshot()
            {
                if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                    MyScreenshot.MakeScreenshot(driver);
            }

            [OneTimeTearDown]
            public static void TearDown()
            {
                //driver.Quit();
            }

        }
    }
