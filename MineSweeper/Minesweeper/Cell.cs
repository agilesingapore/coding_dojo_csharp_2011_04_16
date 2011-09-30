namespace Minesweeper
{
    public class Cell
    {
        public int MineCount { get; set; }

        public static Cell Mine()
        {
            return new Cell { IsMine = true };
        }

        public static Cell NotMine()
        {
            return new Cell();
        }

        public static Cell OutOfBorderCell()
        {
            return new Cell { IsOutOfBorder = true };
        }

        private Cell()
        {
        }

        public bool IsMine { get; private set; }
        public bool IsOutOfBorder { get; private set; }
    }
}