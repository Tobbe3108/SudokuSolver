using System.Threading.Tasks;
using SudokuSolver.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System;

namespace SudokuSolver.Server.Hubs
{
    public class SudokuHub : Hub
    {
        private async Task UpdateTile(TileData updatedTile)
        {
            await Clients.All.SendAsync("ReceiveUpdatedTile", updatedTile);
        }

        public async Task GenerateGrid()
        {
            List<TileData> grid = new List<TileData>();
            Random random = new Random();

            for (int b = 1; b <= 9; b++)
            {
                for (int t = 1; t <= 9; t++)
                {
                    grid.Add(new TileData() { index = Int32.Parse($"{b.ToString()}{t.ToString()}"), Value = random.Next(1, 10) });
                }
            }

            await Clients.All.SendAsync("ReceiveNewGrid", grid);
        }

        public async Task SolveSudoku()
        {
            Random random = new Random();
            await UpdateTile(new TileData() { index = Int32.Parse($"{random.Next(1, 10).ToString()}{random.Next(1, 10).ToString()}"), Value = random.Next(1, 10), Color = "bg-blue-100" });
        }
    }
}