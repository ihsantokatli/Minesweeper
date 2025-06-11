using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineSweeper2
{
    public class Easy: Difficulty
    {
        public Easy()
        {
            Rows = 10;
            Columns = 10;
            Mines = 15;
        }
        public override string ToString()
        {
            return "Easy";
        }
    }
}
