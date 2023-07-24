namespace WebApplication1.Models
{
    public class Board
    {
        public Board()
        {

        }
        public Board(List<List<string?>> board)
        {
            MyBoard = board;
        }
        public List<List<string?>>? MyBoard { get; set; }
        public char? Winner { get; set; }

    }
}
