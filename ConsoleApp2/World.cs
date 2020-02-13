using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace ConsoleApp2
{
    public class World
    {
        public readonly Func<string, string[]> ReadAllLines;
        public readonly Func<string, string[], Unit> WriteAllLines;

        public World(Func<string, string[]> readAllLines, Func<string, string[], Unit> writeAllLines)
        {
            ReadAllLines = readAllLines;
            WriteAllLines = writeAllLines;
        }
    }
}
