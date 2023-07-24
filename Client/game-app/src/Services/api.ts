import axios from 'axios'
import { Board, TicTacToe } from '../models/board..model';

const instance = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
    timeout: 5000,
});

const apiCall = {
    postCell: async (board: Board): Promise<TicTacToe> => {
        try {
            const ticTacTow=(await instance.post('/cell', board.board)).data
            return new TicTacToe(ticTacTow.myBoard,ticTacTow.winner );
        } catch (ex) {
            console.log('====================================');
            console.log(ex);
            console.log('====================================');
            throw ex
        }
    },
}
export default apiCall
