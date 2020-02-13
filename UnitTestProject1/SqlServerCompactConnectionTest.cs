using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlServerCe;
using System.Reflection;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class SqlServerCompactConnectionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var conn = new SqlCeConnection(@"Data Source=..\..\AppData\CDIM.sdf");
            conn.Open();
            var command = new SqlCeCommand("SELECT * FROM  Pla", conn);
            var reader = command.ExecuteReader();

            conn.Close();
            Assert.AreEqual(1, 1);
        }
    }
}
