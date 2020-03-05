using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Shared
{
    public class SudokuService
    {
        public TileData[,] GenerateGridOld()
        {
            TileData[,] grid = new TileData[9, 9];
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    grid[r, c] = new TileData();
                }
            }
            Random random = new Random();

            for (int b = 1; b <= 9; b++)
            {
                for (int t = 1; t <= 9; t++)
                {
                    grid[b, t] = new TileData() { Value = random.Next(1, 10) };
                }
            }

            return grid;
        }

        public TileData[,] GenerateGrid()
        {
            TileData[,] grid = new TileData[9, 9];
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    grid[r, c] = new TileData();
                }
            }

            Random random = new Random();

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    bool generate = false;
                    do
                    {
                        int temp = random.Next(1, 10);

                        if (CheckNeighbourhood(grid, r, c, temp))
                            //    if (CheckVerticalNeighbourhood(grid, cords, temp))
                            //        if (CheckHorizontalNeighbourhood(grid, cords, temp))
                            //            generate = true;

                            if (generate)
                            {
                                grid[r, c] = new TileData() { Value = temp };
                            }
                    } while (!generate);
                }
            }

            return grid;
        }

        private bool CheckNeighbourhood(TileData[,] grid, int r, int c, int temp)
        {
            int rowStart = (r / 3) * 3;
            int colStart = (c / 3) * 3;

            for (int r = rowStart; r < rowStart + 3; r++)
            {
                for (int c = colStart; c < colStart + 3; c++)
                {
                    if (grid[r, c].Value == temp)
                        return false;
                }
            }

            return true;
        }

        //private bool CheckVerticalNeighbourhood(TileData[,] grid, int r, int c, int temp)
        //{
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        if (grid.Find(tile => tile.index.SequenceEqual(new int[2] { i, cords[1] })).Value == temp)
        //            return false;
        //    }

        //    return true;
        //}

        //private bool CheckHorizontalNeighbourhood(TileData[,] grid, int r, int c, int temp)
        //{
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        if (grid.Find(tile => tile.index.SequenceEqual(new int[2] { cords[0], i })).Value == temp)
        //            return false;
        //    }

        //    return true;
        //}
    }
}