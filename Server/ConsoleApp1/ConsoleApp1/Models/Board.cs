using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Board

    {
        public Board()
        {

        }
        public Board(List<List<string>> board)
        {
            MyBoard = board;
            Winner = null;
        }
        public List<List<string>> MyBoard { get; set; }
        public char? Winner { get; set; }
    }
}
