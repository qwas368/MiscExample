using Autofac;
using ConsoleApp2.Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LanguageExt.Prelude;
using JetBrains.Annotations;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ClassLibrary1;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.Entity;
using Unit1 = System.ValueTuple;
using Snowflake.Core;
using LanguageExt.Common;
using System.Net.Http;
using System.Globalization;
using System.Runtime.CompilerServices;
using MediatR;
using Newtonsoft.Json;
using ClassLibrary2.Application.Courses.Commands;
using ClassLibrary2.Application.Courses.Notification;
using MediatR.Pipeline;
using ClassLibrary2.Application.Common.Behaviours;
using FSharpClassLibrary;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using Unit = Microsoft.FSharp.Core.Unit;
using Microsoft.FSharp.Core;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using BenchmarkDotNet.Running;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2
{
    public class TestModel
    {
        [Column(Order = 1)]
        public string p1 { get; set; }

        [Column(Order = 2)]
        public string p2 { get; set; }

        [Column(Order = 2)]
        public string p3 { get; set; }

        [Column(Order = 2)]
        public string p4 { get; set; }

        [Column(Order = 2)]
        public string p5 { get; set; }

        [Column(Order = 2)]
        public string p6 { get; set; }
    }

    public class Test<T>
    {
        object model = new TestModel();

        public Test()
        {
        }

        [Benchmark]
        public void GetValue()
        {
            var r = (model as TestModel).p1;
        }

        [Benchmark]
        public void ToDictionary()
        {
            var dic = new Dictionary<string, object>();
            var tm = model as TestModel;
            dic.Add("p1", tm.p1);
            dic.Add("p2", tm.p2);
            dic.Add("p3", tm.p3);
            dic.Add("p4", tm.p4);
            dic.Add("p5", tm.p5);
            dic.Add("p6", tm.p6);
        }

        [Benchmark]
        public void GetType() 
        {
            var r = typeof(T);
        }

        [Benchmark]
        public void GetSpecificProperty()
        {
            var r = typeof(T).GetProperty("p1");
        }

        [Benchmark]
        public void GetSpecificPropertyValue()
        {
            var propertyInfo = typeof(T).GetProperty("p1");
            propertyInfo.GetValue(model, null);
        }

        [Benchmark]
        public void GetProperties()
        {
            var r = typeof(T).GetProperties();
        }

        [Benchmark]
        public void GetPropertiesValue()
        {
            typeof(T).GetProperties().ToList().ForEach(p => p.GetValue(model, null));
        }


        [Benchmark]
        public void GetAttrubuties()
        {
            var r = typeof(T).GetProperties().Select(p => p.GetCustomAttribute<ColumnAttribute>()).ToArray();
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string sql = 
                @"SELECT * FROM ABC
                WHERE ABC.a = 1";

            Console.ReadKey();
        }
    }
}


