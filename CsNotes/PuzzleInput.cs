using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUtils
{
    public class PuzzleInput
    {
        public static string ReadAllText()
        {
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            var inputPath = Path.Combine(projectRoot!, "input.txt");
            var input = File.ReadAllText(inputPath);
            return input;
        }
    }
}
