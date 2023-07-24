interface IBoard {
    board: Array<Array<String | null>>;
    getCell(row: number, column: number): String | null;
    setCell(row: number, column: number, value: String | null): void;
}

export class Board implements IBoard {
    public board: Array<Array<String | null>>;

    constructor(board: Array<Array<String | null>>) {
        this.board = board;
    }
    getCell(row: number, column: number): String | null {
        if (this.board) {
            return this.board[row][column];
        } else {
            throw 'board is not exists.'
        }
    }

    setCell(row: number, column: number, value: String | null) {
        if (this.board) {
            this.board[row][column] = value;
        } else {
            throw 'board is not exists.'
        }
    }
}

export class TicTacToe {
    public myBoard: Board;
    public winner: String | null;
    constructor(myBoard: Board, winner: String | null = null) {
        this.myBoard = new Board(myBoard);
        this.winner = winner;

    }
}