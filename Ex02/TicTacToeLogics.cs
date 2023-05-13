using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class TicTacToeLogics
    {
        private Player m_Player1, m_Player2;
        private Player m_CurrentPlayer;
        private TicTacToeBoard m_Board;
        
        public TicTacToeLogics(int i_sizeOfBoard, int i_numOfPlayers) 
        {
            m_Board = new TicTacToeBoard(i_sizeOfBoard);
            const bool v_isNotBot = false;

            if ( i_numOfPlayers == 1)
            {
                m_Player1 = new Player(CellValue.X, v_isNotBot);
                m_Player2 = new Player(CellValue.O, !v_isNotBot);   
            }
            else
            {
                m_Player1 = new Player(CellValue.X, v_isNotBot);
                m_Player2 = new Player(CellValue.O, v_isNotBot);
            }
            m_CurrentPlayer = m_Player1;
        }
        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }
        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }
        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }
        public TicTacToeBoard BoardState
        {
            get
            {
                return m_Board;
            }
        }
        public Player GetPlayerBySymbole(CellValue symbole)
        {
            Player player = null;
            if ( symbole == CellValue.X )
            {
                player = m_Player1;
            }
            else if ( symbole == CellValue.O )
            {
                player = m_Player2;
            }
            return player;
        }
        internal bool PlayersMove(int i_iIndex, int i_jIndex)
        {
            bool isSymbolePlaced = m_Board.PlaceSymbole(m_CurrentPlayer.Symbole, i_iIndex, i_jIndex);
            if (isSymbolePlaced)
            {
                if (m_CurrentPlayer == m_Player1)
                {
                    m_CurrentPlayer = m_Player2;
                }
                else
                {
                    m_CurrentPlayer = m_Player1;
                }
            }
            return isSymbolePlaced;
        }
        internal bool ComputersMove()
        {
            bool validTurn = false;
            int row, col;
            Random random = new Random();
            while(!validTurn)
            {
                row = random.Next(m_Board.Size);
                col = random.Next(m_Board.Size);   
                if(m_Board.IsPlaceOnBoard())
                {
                    validTurn = PlayersMove(row, col);
                }
            }

            return validTurn;
        }
        public bool WinningStatus(out CellValue o_WinnerSymbole)
        {
            bool isGameOver = false;
            o_WinnerSymbole = m_Board.GetWinner();
            if(o_WinnerSymbole == CellValue.Empty)
            {
                isGameOver  = !m_Board.IsPlaceOnBoard();
                // no winner and no place on the board = its a tie
            }
            else
            {
                isGameOver = true;
                GetPlayerBySymbole(o_WinnerSymbole).IncrementScore();
                // o_WinnerSymbole = X or O -> gameover
            }
            return isGameOver;

        }
        public void ResetGame()
        {
            m_CurrentPlayer = m_Player1;
            m_Board.ResetBoard();
        }
        private TicTocToeMove MiniMax(TicTacToeBoard i_board, CellValue i_playerSymbole)
        {
            // Base case: check if the game has ended
            if (m_Board.GetWinner()==CellValue.X)
            {
                return new TicTocToeMove(-1, -1, -1);
            }
            else if (m_Board.GetWinner() == CellValue.O)
            {
                return new TicTocToeMove(-1, -1, 1);
            } 
            else if (!(m_Board.IsPlaceOnBoard()))
            {
                return new TicTocToeMove(-1, -1, 0);
            }
               
            List<TicTocToeMove> moves = new List<TicTocToeMove>();

            // Generate all possible moves and calculate their scores
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (m_Board.GetCell(row, col) == CellValue.Empty)
                    {
                        // Apply the move to the board
                        bool isSymbolePlaced = m_Board.PlaceSymbole(i_playerSymbole, row, col);
                        
                        // Calculate the score of the move by recursively calling MiniMax for the opponent player
                        TicTocToeMove move = new TicTocToeMove(row, col, MiniMax(m_Board, (i_playerSymbole == m_Player2.Symbole) ? m_Player1.Symbole : m_Player2.Symbole).Score);
                        
                        // Reset the move on the board
                        isSymbolePlaced = m_Board.PlaceEmptySymbole(CellValue.Empty, row, col); 
                       
                        moves.Add(move);
                    }
                }
            }

            // Select the best move based on the player's turn
            TicTocToeMove bestMove = moves[0];
            GetBestMove(ref bestMove, ref moves, i_playerSymbole);
            
            return bestMove;
        }
        private void GetBestMove(ref TicTocToeMove io_move, ref List<TicTocToeMove> io_moves, CellValue i_playerSymbole)
        {
            if (i_playerSymbole == m_Player2.Symbole)
            {
                int bestScore = int.MinValue;
                foreach (TicTocToeMove move in io_moves)
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
                foreach (TicTocToeMove move in io_moves)
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

