using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public class Order
        {
            public string Price() =>
                "12345";
        }

        [TestMethod]
        public void TestMethod1()
        {
            var array = Enum.GetValues(typeof(DayOfWeek));
            var array2 = array.Cast<DayOfWeek>();

            var dic = new Dictionary<string, string>()
            {
                ["gg"] = "gg",
                ["false"] = "gg",
            };

            var b = dic["gg"];
        }
    }
}
