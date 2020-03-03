using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Shared
{
    public class SudokuState
    {
        public List<TileData> CurrentGrid { get; private set; }

        private HubConnection connection;

        public SudokuState()
        {
            connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44336/SudokuHub")
            .WithAutomaticReconnect()
            .Build();

            connection.On<TileData>("ReceiveUpdatedTile", (updatedTile) =>
            {
                CurrentGrid[CurrentGrid.FindIndex(tile => tile.index == updatedTile.index)] = updatedTile;
                OnStateChanged?.Invoke();
            });

            connection.On<List<TileData>>("ReceiveNewGrid", (grid) =>
            {
                CurrentGrid = grid;
                OnStateChanged?.Invoke();
            });

            Task.Run(() => connection.StartAsync());
        }

        public event Action OnStateChanged;
    }
}