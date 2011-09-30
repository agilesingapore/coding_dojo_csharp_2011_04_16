using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Minesweeper
{
    public class Field
    {
        private readonly Cell[][] _field;

        public Field(Cell[][] field)
        {
            _field = field;

            CountMinesInField();
        }

        public int Width { get { return _field[0].Length; } }
        public int Height { get { return _field.Length; } }
        public Cell this[int row, int column]
        {
            get { return IsWithinBounds(row, column) ? _field[row][column] : Cell.OutOfBorderCell(); }
        }

        private void CountMinesInField()
        {
            foreach (var row in Enumerable.Range(0, _field.Length))
                foreach (var col in Enumerable.Range(0, _field[row].Length))
                    _field[row][col].MineCount = GetAdjacentCells(row, col).Count(c => c.IsMine);
        }

        IEnumerable<Cell> GetAdjacentCells(int row, int col)
        {
            yield return this[row - 1, col - 1];
            yield return this[row - 1, col];
            yield return this[row - 1, col + 1];
            yield return this[row, col - 1];
            yield return this[row, col + 1];
            yield return this[row + 1, col - 1];
            yield return this[row + 1, col];
            yield return this[row + 1, col + 1];
        }

        private bool IsWithinBounds(int row, int col)
        {
            return !(row < 0 || col < 0 || _field.Length <= row || _field[row].Length <= col);
        }
    }
}