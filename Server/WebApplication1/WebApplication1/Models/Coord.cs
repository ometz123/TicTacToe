namespace WebApplication1.Models
{
    public class Coord
    {

        public Coord(int col, int row)
        {
            Col = col; Row = row;
        }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}
