using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetExample
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

}
