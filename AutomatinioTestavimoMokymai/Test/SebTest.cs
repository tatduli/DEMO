using AutomatinioTestavimoMokymai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai.Test
{
    public class SebTest : BaseTest
    {
        
        [TestCase("1000", "0", "Klaipėda", "75000", TestName = "Ar duos paskolą")]
        public static void TestArDuosPaskola(string pajamos, string isipareigojimai, string miestas, int paskola)
        {
            sebPage.NavigateToDefaultPage();
            sebPage.CloseCookies();
            sebPage.FocusOnFrame();
            
            sebPage.Pajamos(pajamos);
            sebPage.Isipareigojimais(isipareigojimai);
            sebPage.SelectFromByText(miestas);
            sebPage.ChlickOnResultBotton();
            sebPage.VerifyResult(paskola);

        }

    }
}
