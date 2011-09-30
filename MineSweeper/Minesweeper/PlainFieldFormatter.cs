using System;

namespace Minesweeper
{
    public class PlainFieldFormatter
    {
        public string Format(Field field)
        {
            var result = "";
            for (var row = 0; row < field.Height; row++)
            {
                result += Environment.NewLine;

                for (var col = 0; col < field.Width; col++)
                {
                    var cell = field[row, col];
                    result += cell.IsMine ? "*" : cell.MineCount.ToString();
                }
            }

            return result.Trim();
        }
    }
}