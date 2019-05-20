using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MinesweeperModel
    {
        private readonly bool[,]  _board;
        public int SizeX { get; }
        public int SizeY { get; }

        public MinesweeperModel(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            _board = new bool[SizeX,SizeY];
        }

        public void MakeMove(int x, int y)
        {
            _board[x, y] = !_board[x, y];
        }
        public bool this[int x, int y]
        {
            get { return _board[x, y]; }
        }

    }
}