using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetExample
{
    public class SqlConnectionTest
    {
        private DbConnection _cnn;
        public SqlConnectionTest()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\Source"));
            _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
            _cnn.Open();
        }

        [Benchmark]
        public void Reconnect()
        {
            using (DbConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString))
            {
                cnn.Open();
                cnn.CreateCommand();
            }
        }

        [Benchmark]
        public void Reconnect2()
        { 
            DbConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
            cnn.Open();
            cnn.CreateCommand();
            cnn.Close();
        }

        [Benchmark]
        public void Noreconnection()
        {
            _cnn.CreateCommand();
            _cnn.CreateCommand();
            _cnn.CreateCommand();
            _cnn.CreateCommand();
        }
    }
}
