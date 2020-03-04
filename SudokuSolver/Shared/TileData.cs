using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Shared
{
    public class TileData
    {
        public int[] index { get; set; }
        public int? Value { get; set; }
        public string Color { get; set; }
    }
}