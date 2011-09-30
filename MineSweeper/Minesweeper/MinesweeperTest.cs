using System;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Minesweeper
{
    [TestFixture]
    public class MinesweeperTest
    {
        private static void ShouldParse(string input, string output)
        {
            var field = PlainFieldParser.Parse(input);
            var fieldFormatter = new PlainFieldFormatter();

            fieldFormatter.Format(field).Should().Be(output.Trim());
        }



        [Test]
        public void GenerateEmptyField()
        {
            string input = @"
....
....
....
";


            string output = @"
0000
0000
0000";
            ShouldParse(input, output);
        }

        [Test]
        public void MineAndEmptyCell()
        {
            ShouldParse(@"*.", @"*1");
        }

        [Test]
        public void OneMine()
        {
            ShouldParse(@"*", @"*");
        }

        [Test]
        public void TwoMines()
        {
            ShouldParse(@"**", @"**");
        }

        [Test]
        public void OneMineMultipleRows()
        {
            ShouldParse(@"
*...
....
.*..
....", @"
*100
2210
1*10
1110");
        }

    }
}