using System;
using System.Drawing;
using System.Windows.Forms;

namespace mineSweeper2
{
    internal class Cell : Button
    {
        private bool isMine;
        private bool isRevealed;
        private bool isFlagged;
        private int adjacentMines;
        

        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;

            Width = 50;
            Height = 50;
            BackColor = Color.LightGray;

            

        }
        


        public bool IsMine
        {
            get { return isMine; }
            set { isMine = value; }
        }

        public bool IsRevealed
        {
            get { return isRevealed; }
            set { isRevealed = value; }
        }

        public bool IsFlagged
        {
            get { return isFlagged; }
            set { isFlagged = value; }
        }

        public int AdjacentMines
        {
            get { return adjacentMines; }
            set { adjacentMines = value; }
        }
    }
}