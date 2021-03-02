using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinioTestavimoMokymai
{
    public class PirmasUzsiemimas
    {
        [Test]
        public static void TestasAr4Lyginis()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

        [Test]
        public static void TestNowIs18()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(18, currentTime.Hour, "Now isn't 18");
        }
        [Test]
        public static void Or995Dived3()
        {
            Assert.AreEqual(0, 995 % 3, "995 isn't dived 3");
        }

        [Test]
        public static void TestTodayIsWensday()
        {
            DayOfWeek currentWeekDay = DayOfWeek.Wednesday;
            Assert.AreEqual(currentWeekDay, DateTime.Today.DayOfWeek, "Today isn't Wensday");
        }

        [Test]
        public static void TestWait5s()
        {
            Thread.Sleep(5000);
        }
    }
}
