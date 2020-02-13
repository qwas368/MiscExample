using ConsoleApp2;
using ConsoleApp2.Monad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.IO;
using System.Linq;
using static LanguageExt.Prelude;

namespace UnitTestProject1
{
    [TestClass]
    public class MonadTest
    {
        [TestMethod]
        public void ReaderTest()
        {
            var AddLineNumbers = fun((string[] lines) =>
                                        lines.Zip(Naturals)
                                             .Select(pair => $"{pair.Item2}: {pair.Item1}")
                                             .ToArray());

            var world = new World(File.ReadAllLines, fun<string, string[]>(File.WriteAllLines));
            var g =  from lines in ConsoleApp2.Monad.Reader.ReadAllLines("")
                     from _     in ConsoleApp2.Monad.Reader.WriteAllLines("", AddLineNumbers(lines))
                     select _;

            g(world);
        }

        [TestMethod]
        public void OptionTest()
        {
            var r = from a in Some("Hello")
                    from b in Some("World")
                    select $"{a} {b}";

            var r2 = from a in Some("Hello")
                     from b in None
                     select $"{a} {b}";


            Assert.AreEqual(r.IsSome, true);
            Assert.AreEqual(r2.IsSome, false);
        }

        public Subsystem<string> ErrorHappened() =>
            from a in Subsystem.Fail<string>("error")
            select a;

        [TestMethod]
        public void SubsystemTest1()
        {
            var expr = from a in Subsystem.Return<string>("Hello")
                       from b in Subsystem.Return<string>("World")
                       from c in ErrorHappened()
                       select a + b + c;

            var r = expr.Execute();

            Assert.AreEqual(r.IsSucceed, true);
            Assert.AreEqual(r.Value, "HelloWorld");
        }

        [TestMethod]
        public void SubsystemTest2()
        {
            B();
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();

            var expr = from a in Subsystem.Return<string>("Hello")
                       let c = "Dummy"
                       from b in Subsystem.Fail<string>("Error happend")
                       select a + c;

            var r = expr.Execute();

            Assert.AreEqual(r.IsFailed, true);
            r.Error.IfSome(err => Assert.AreEqual(err.Message, "Error happend"));
        }

        [TestMethod]
        public void SubsystemTest3()
        {
            var expr = from a in Subsystem.Return<string>("Hello")
                       let c = fun(() => { throw new System.Exception(); })()
                       from b in Subsystem.Fail<string>("Error happend")
                       select a + c;

            var r = expr.Execute();

            r.Value.ShouldBe("");
            Assert.AreEqual(r.Value, "");
            Assert.AreEqual(r.IsFailed, true);
        }

        [TestMethod]
        public void 用中文命名的測試()
        {
            Assert.IsNotNull("這是一個用中文命名的測試");
        }

        [TestMethod]
        public void 用中英文命名的測試Test()
        {
            Assert.IsNotNull("這是一個用中文命名的測試");
        }

        private void A()
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
        }

        private void B()
        {
            A();
        }
    }
}
