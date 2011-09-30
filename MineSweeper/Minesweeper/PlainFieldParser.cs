using System;
using System.Linq;

namespace Minesweeper
{
    public class PlainFieldParser
    {
        public static Field Parse(string input)
        {
            var inputLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return new Field(inputLines.Select(line => line.Select(c => c == '*' ? Cell.Mine() : Cell.NotMine()).ToArray()).ToArray());
        }
    }
}