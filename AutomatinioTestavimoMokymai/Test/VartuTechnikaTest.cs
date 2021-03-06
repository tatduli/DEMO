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
    public class VartuTechnikaTest : BaseTest
    {     
        [TestCase("2000", "2000", true, false, "665.98", TestName = "02000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000 X 2000 = 692.35")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]

        public void TestVartuTechnika(string width, string high,
                                      bool auto, bool work, string result)
        {
            vartuTechnikaPage.NavigateToDefaultPage()
                             .InsertHighAndWith(width, high)
                             .CheckBoxAuto(auto)
                             .CheckBoxWork(work)
                             .ClickCalculateButton()
                             .CheckResult(result);
        }
    }
}
