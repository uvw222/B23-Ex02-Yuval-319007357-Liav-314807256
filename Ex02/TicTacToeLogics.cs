using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class TicTacToeLogics
    {
        private Player m_Player1, m_Player2, m_CurrentPlayer;
        private TicTacToeBoard m_Board;
        private bool m_Players2Turn = false;
        
        public TicTacToeLogics(int i_sizeOfBoard, int i_numOfPlayers) 
        {
            m_Board = new TicTacToeBoard(i_sizeOfBoard);
            if ( i_numOfPlayers == 1)
            {
                //m_Player1 = new Player(true);
               
            }
        }

        public TicTacToeBoard BoardState
        {
            get
                { return m_Board.BoardState; }
        }

        public bool PlayersMove(int i_iIndex, int i_jIndex)
        {
            bool isSymbolePlaced = m_Board.PlaceSymbole(m_CurrentPlayer.Symbole, i_iIndex, i_jIndex);
            if(isSymbolePlaced)
            {
                if (m_CurrentPlayer == m_Player1)
                {
                    m_CurrentPlayer = m_Player2;
                }   
                else
                {
                    m_CurrentPlayer = m_Player1;
                }

            return isSymbolePlaced;
        }



        public bool WinningStatus(out CellValue o_WinnerSymbole)
        {
            bool isGameOver = false;
            o_WinnerSymbole = m_Board.GetWinner()
            if(o_WinnerSymbole == CellValue.Empty)
            {
                isGameOver  = !m_Board.IsPlaceOnBoard();
                // no winner and no place on board = its a tie
            }
            else
            {
                isGameOver = true;
                // o_WinnerSymbole = X or O -> gameover
            }
            return isGameOver;

        }
    }
}
