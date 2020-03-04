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
            bool insert = true;

            for (int b = 1; b <= 9; b++)
            {
                for (int t = 1; t <= 9; t++)
                {
                    var temp = random.Next(1, 10);

                    //Check tiles in current grid
                    for (int n = 1; n <= 9; n++)
                    {
                        TileData tile = grid.Find(tile => tile.index.SequenceEqual(new int[2] { t, n }));
                        if (tile != null)
                            if (grid.Find(tile => tile.index.SequenceEqual(new int[2] { t, n })).Value == temp)
                                insert = false;
                    }

                    //Check vertical neighbours
                    for (int i = 1; i <= 9; i++)
                    {
                        if (grid.Find(tile => tile.index.SequenceEqual(new int[2] { b, i })).Value == temp)
                            insert = false;
                    }

                    //Check Horisontal neignbours
                    for (int i = 1; i <= 9; i++)
                    {
                        if (grid.Find(tile => tile.index.SequenceEqual(new int[2] { t, i })).Value == temp)
                            insert = false;
                    }

                    if (!insert)
                    {
                        grid.Add(new TileData() { index = new int[2] { b, t }, Value = random.Next(1, 10) });
                    }
                }
            }

            return grid;
        }
    }
}
