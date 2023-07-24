using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Coord

    {
        public Coord()
        {

        }
        public Coord(int col, int row)
        {
            Col = col; Row = row;
        }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}
