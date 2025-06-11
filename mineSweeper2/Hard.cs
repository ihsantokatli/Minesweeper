using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineSweeper2
{
    public class Hard : Difficulty
    {
        public Hard()
        {
            Rows = 16;
            Columns = 30;
            Mines = 99;
        }
        public override string ToString()
        {
            return "Hard";
        }
    }


}
