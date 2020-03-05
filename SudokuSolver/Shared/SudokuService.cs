using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Shared
{
    public class SudokuService
    {
        public List<TileData> GenerateGridOld()
        {
            List<TileData> grid = new List<TileData>();
            Random random = new Random();

            for (int b = 1; b <= 9; b++)
            {
                for (int t = 1; t <= 9; t++)
                {
                    grid.Add(new TileData() { index = new int[2] { b, t }, Value = random.Next(1, 10) });
                }
            }

            return grid;
        }

        public List<TileData> GenerateGrid()
        {
            List<TileData> grid = new List<TileData>();
            Random random = new Random();

            for (int c = 1; c <= 9; c++)
            {
                for (int r = 1; r <= 9; r++)
                {
                    int temp = random.Next(1, 10);
                    CheckNeighbourhood(grid, new int[2] { 5, 6 }, temp);
                }
            }


            return grid;
        }

        private bool CheckNeighbourhood(List<TileData> grid, int[] cords, int temp)
        {

            int rowStart = (cords[0] / 3) * 3;
            int colStart = (cords[1] / 3) * 3;

            for (int n = 1; n <= 9; n++)
            {
                TileData tile = grid.Find(tile => tile.index.SequenceEqual(cords));
                if (tile != null)
                    if (tile.Value == temp)
                        return false;
            }

            return true;
        }

        //private bool CheckVerticalNeighbourhood()
        //{
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        TileData tile = grid.Find(tile => tile.index.SequenceEqual(new int[2] { b, i }));
        //        if (tile != null)
        //            if (tile.Value == temp)
        //                insert = false;
        //    }

        //    return true;
        //}

        //private bool CheckHorizontalNeighbourhood()
        //{
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        TileData tile = grid.Find(tile => tile.index.SequenceEqual(new int[2] { t, i }));
        //        if (tile != null)
        //            if (tile.Value == temp)
        //                insert = false;
        //    }

        //    return true;
        //}

    }
}
