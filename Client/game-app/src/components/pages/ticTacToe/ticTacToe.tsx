import { useState } from 'react';
import './TicTacToeGame.css';
import apiCall from '../../../Services/api';
import { Board } from '../../../models/board..model';

const TicTacToeGame = () => {
  const [boardSize, setBoardSize] = useState(3);
  const [board, setBoard] = useState<Board>(createEmptyBoard(boardSize));
  const [currentPlayer, setCurrentPlayer] = useState<String>('X');
  const [winner, setWinner] = useState<String | null>("");

  function createEmptyBoard(size: number): Board {
    return new Board(Array.from({ length: size }, () => Array(size).fill(null)));
  }


  async function handleCellClick(row: number, col: number) {
    if (!board.getCell(row, col) && !winner) {
      const newBoard = new Board(board.board)
      newBoard.setCell(row, col, currentPlayer);
      setBoard(newBoard);
      const ticTacToe = await apiCall.postCell(board);

      setBoard(ticTacToe.myBoard)
      if (ticTacToe.winner === currentPlayer) {
        setWinner(currentPlayer);
      } else if (ticTacToe.winner === 'O') {
        setWinner('Computer');
      }
      else if (ticTacToe.winner === '-') {
        setWinner('Draw');
      }
    }
  }

  function handleClearBoard() {
    setBoard(createEmptyBoard(boardSize));
    setCurrentPlayer('X');
    setWinner("");
  }

  return (
    <div className="tic-tac-toe-game">
      <div>
        <label>
          Board Size:
          <select
            value={boardSize}
            onChange={(e) => {
              const selectedSize = parseInt(e.target.value);
              setBoardSize(selectedSize);
              setBoard(createEmptyBoard(selectedSize));
              setCurrentPlayer('X');
              setWinner("");
            }}
          >
            <option value="3">3x3</option>
            <option value="4">4x4</option>
            <option value="5">5x5</option>
          </select>
        </label>
      </div>
      <table className="board">
        <tbody>
          {board?.board?.map((row, rowIndex) => (
            <tr key={rowIndex}>
              {row.map((cell, colIndex) => (
                <td
                  key={colIndex}
                  className="cell"
                  onClick={() => handleCellClick(rowIndex, colIndex)}
                >
                  {cell}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
      {winner && <div>Winner: {winner}</div>}
      {!winner && board?.board?.flat().every((cell) => cell !== null) && <div>It's a draw!</div>}
      <div>
        <button onClick={handleClearBoard}>Clear Board</button>
      </div>
    </div>
  );
};

export default TicTacToeGame;
