using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class TicTacToeAI
    {
       
        internal bool ComputersMove(TicTacToeLogics i_logics, ref Player io_computerPlayer,  Player io_humanPlayer )
        {
            TicTocToeAIMove bestMove = MiniMax(i_logics.BoardState, io_computerPlayer.Symbole);
            bool isSymbolePlaced = i_logics.BoardState.PlaceSymbole(io_computerPlayer.Symbole, bestMove.Row, bestMove.Col);
            if (isSymbolePlaced)
            {
                i_logics.CurrentPlayer=i_logics.Player1;
            }
            return isSymbolePlaced;
        }
        private TicTocToeAIMove MiniMax(TicTacToeBoard i_board, CellValue i_playerSymbole)
        {
            // Base case: check if the game has ended
            if (i_board.GetWinner() == CellValue.X)
            {
                return new TicTocToeAIMove(-1, -1, -1);
            }
            else if (i_board.GetWinner() == CellValue.O)
            {
                return new TicTocToeAIMove(-1, -1, 1);
            }
            else if (!(i_board.IsPlaceOnBoard()))
            {
                return new TicTocToeAIMove(-1, -1, 0);
            }

            List<TicTocToeAIMove> moves = new List<TicTocToeAIMove>();

            // Generate all possible moves and calculate their scores
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (i_board.GetCell(row, col) == CellValue.Empty)
                    {
                        // Apply the move to the board
                        bool isSymbolePlaced = i_board.PlaceSymbole(i_playerSymbole, row, col);

                        // Calculate the score of the move by recursively calling MiniMax for the opponent player
                        TicTocToeAIMove move = new TicTocToeAIMove(row, col, MiniMax(i_board, (i_playerSymbole == CellValue.O) ? CellValue.X : CellValue.O).Score);

                        // Reset the move on the board
                        isSymbolePlaced = i_board.PlaceEmptySymbole(CellValue.Empty, row, col);

                        moves.Add(move);
                    }
                }
            }

            // Select the best move based on the player's turn
            TicTocToeAIMove bestMove = moves[0];
            GetBestMove(ref bestMove, ref moves, i_playerSymbole);

            return bestMove;
        }
        private void GetBestMove(ref TicTocToeAIMove io_move, ref List<TicTocToeAIMove> io_moves, CellValue i_playerSymbole)
        {
            if (i_playerSymbole == CellValue.O)
            {
                int bestScore = int.MinValue;
                foreach (TicTocToeAIMove move in io_moves)
                {
                    if (move.Score > bestScore)
                    {
                        bestScore = move.Score;
                        io_move = move;
                    }
                }
            }
            else
            {
                int bestScore = int.MaxValue;
                foreach (TicTocToeAIMove move in io_moves)
                {
                    if (move.Score < bestScore)
                    {
                        bestScore = move.Score;
                        io_move = move;
                    }
                }
            }
        }
    }
}
