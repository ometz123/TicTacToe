using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class TicTacToe

    {

        public TicTacToe()
        {

        }
        public Board NextMove(Board board)
        {
            if (CheckForWinner(board, "X"))
            {
                board.Winner = 'X';
            }
            else if (CheckForWinner(board, "O"))
            {
                board.Winner = 'O';
            }
            else
            {
                List<Coord> nullCoords = new List<Coord>();
                for (int col = 0; col < board.MyBoard.Count(); col++)
                {
                    for (int row = 0; row < board.MyBoard[col].Count(); row++)
                    {
                        if (board.MyBoard[col][row] == null)
                        {
                            nullCoords.Add(new Coord(col, row));
                        }
                    }
                }
                if (nullCoords.Count() == 0)
                {
                    board.Winner = '-';
                }
                else
                {
                    int rnd = new Random().Next(nullCoords.Count);
                    board.MyBoard[nullCoords[rnd].Col][nullCoords[rnd].Row] = "O";

                    if (CheckForWinner(board, "O"))
                    {
                        board.Winner = 'O';
                    }
                }
            }
            return board;
        }
        private bool CheckForWinner(Board board, string currentPlayer)
        {
            // Check rows for a win
            for (int i = 0; i < board.MyBoard.Count; i++)
            {
                bool rowWin = true;
                for (int j = 0; j < board.MyBoard.Count; j++)
                {
                    if (board.MyBoard[i][j] != currentPlayer)
                    {
                        rowWin = false;
                        break;
                    }
                }

                if (rowWin)
                    return true;
            }

            // Check columns for a win
            for (int i = 0; i < board.MyBoard.Count; i++)
            {
                bool colWin = true;
                for (int j = 0; j < board.MyBoard.Count; j++)
                {
                    if (board.MyBoard[j][i] != currentPlayer)
                    {
                        colWin = false;
                        break;
                    }
                }

                if (colWin)
                    return true;
            }

            // Check main diagonal for a win
            bool mainDiagonalWin = true;
            for (int i = 0; i < board.MyBoard.Count; i++)
            {
                if (board.MyBoard[i][i] != currentPlayer)
                {
                    mainDiagonalWin = false;
                    break;
                }
            }

            if (mainDiagonalWin)
                return true;

            // Check anti-diagonal for a win
            bool antiDiagonalWin = true;
            for (int i = 0; i < board.MyBoard.Count; i++)
            {
                if (board.MyBoard[i][board.MyBoard.Count - i - 1] != currentPlayer)
                {
                    antiDiagonalWin = false;
                    break;
                }
            }

            if (antiDiagonalWin)
                return true;

            return false;
        }

    }
}
