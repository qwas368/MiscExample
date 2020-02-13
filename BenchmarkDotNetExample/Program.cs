using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using Unit1 = System.ValueTuple;
using System.Net.Http;
using System.Globalization;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using BenchmarkDotNet.Running;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkDotNetExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var summery = BenchmarkRunner.Run(typeof(Test<TestModel>).Assembly);

            Console.ReadKey();
        }
    }
}


