using System.Threading.Tasks;
using SudokuSolver.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SudokuSolver.Server.Hubs
{
    public class SudokuHub : Hub
    {
        private SudokuService _sudokuService { get; set; }

        public SudokuHub(SudokuService sudokuService)
        {
            _sudokuService = sudokuService;
        }

        public async Task GenerateGrid()
        {
            await Clients.All.SendAsync("ReceiveNewGrid", _sudokuService.GenerateGrid());
        }
    }
}