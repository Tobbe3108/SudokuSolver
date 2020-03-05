using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Shared
{
    public class SudokuService
    {
        public List<TileData> GenerateGrid()
        {
            List<TileData> grid = new List<TileData>();

            Random random = new Random();

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    bool generate = true;
                    do
                    {
                        int temp = random.Next(1, 10);

                        //if (CheckNeighbourhood(grid, r, c, temp))
                        //    if (CheckVerticalNeighbourhood(grid, c, temp))
                        //        if (CheckHorizontalNeighbourhood(grid, r, temp))
                        //            generate = true;

                        if (generate)
                        {
                            grid.Add(new TileData() { index = new int[] { r, c }, Value = temp });
                        }
                    } while (!generate);
                }
            }

            return grid;
        }

        private bool CheckNeighbourhood(List<TileData> grid, int r, int c, int temp)
        {
            int rowStart = (r / 3) * 3;
            int colStart = (c / 3) * 3;

            for (int row = rowStart; row < rowStart + 3; row++)
            {
                for (int col = colStart; col < colStart + 3; col++)
                {
                    if (grid.Find(tile => tile.index.SequenceEqual(new int[] { row, col })).Value == temp)
                        return false;
                }
            }

            return true;
        }

        private bool CheckVerticalNeighbourhood(List<TileData> grid, int c, int temp)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid.Find(tile => tile.index.SequenceEqual(new int[] { i, c })).Value == temp)
                    return false;
            }

            return true;
        }

        private bool CheckHorizontalNeighbourhood(List<TileData> grid, int r, int temp)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid.Find(tile => tile.index.SequenceEqual(new int[] { r, i })).Value == temp)
                    return false;
            }

            return true;
        }
    }
}