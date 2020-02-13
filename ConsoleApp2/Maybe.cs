using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class Maybe<a>
    {
        internal static readonly Maybe<a> _unique_None = new _None();

        public static Maybe<a> None {
            get
            {
                return _unique_None;
            }
        }

        internal class _None : Maybe<a>
        {
            internal _None()
            {
            }

            public override string ToString()
            {
                return "None";
            }
        }

        public int Tag { get; }

        public static class Tags
        {
            public const int Some = 0;
            public const int None = 1;
        }

        public override string ToString()
        {
            return ExtraTopLevelOperators.PrintFormatToString(new PrintfFormat<FSharpFunc<Maybe<a>, string>, Unit, string, string, Maybe<a>>("%+A")).Invoke(this);
        }
    }
}
