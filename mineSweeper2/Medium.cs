using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineSweeper2
{
    public class Medium: Difficulty
    {
        public Medium()
        {
            Rows = 16;
            Columns = 16;
            Mines = 40;
        }
        public override string ToString()
        {
            return "Medium";
        }
    }
}
