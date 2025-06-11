using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineSweeper2
{
    public abstract class Difficulty
    {
        int rows;
        int columns;
        int mines;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        public int Mines
        {
            get { return mines; }
            set { mines = value; }
        }

    }
}
