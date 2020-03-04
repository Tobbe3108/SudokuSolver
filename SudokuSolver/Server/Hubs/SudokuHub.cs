using System.Threading.Tasks;
using SudokuSolver.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System;

namespace SudokuSolver.Server.Hubs
{
    public class SudokuHub : Hub
    {
        private SudokuService _sudokuService { get; set; }
        public SudokuHub(SudokuService sudokuService)
        {
            _sudokuService = sudokuService;
        }

        private async Task UpdateTile(TileData updatedTile)
        {
            await Clients.All.SendAsync("ReceiveUpdatedTile", updatedTile);
        }

        public async Task GenerateGrid()
        {
            await Clients.All.SendAsync("ReceiveNewGrid", _sudokuService.GenerateGridOld());
        }

        public async Task GenerateGridNew()
        {
            await Clients.All.SendAsync("ReceiveNewGrid", _sudokuService.GenerateGrid());
        }

        public async Task SolveSudoku()
        {
            Random random = new Random();
            await UpdateTile(new TileData() { index = new int[2] { random.Next(1, 10), random.Next(1, 10) }, Value = random.Next(1, 10), Color = "bg-blue-100" });
        }
    }
}