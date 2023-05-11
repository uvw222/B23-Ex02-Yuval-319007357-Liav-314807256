using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class TicTacToeLogics
    {
        Player m_Player1, m_Player2;
        TicTacToeBoard m_Board;
        bool m_Players2Turn = false;
        
        public TicTacToeLogics(int i_sizeOfBoard, int i_numOfPlayers) 
        {
            m_Board = new TicTacToeBoard(i_sizeOfBoard);
            if ( i_numOfPlayers == 1)
            {
                //m_Player1 = new Player(true);
               
            }
        }

        public bool PlayersMove(int i_iIndex, int i_jIndex)
        {
            bool isSymbolePlaced = m_Board.PlaceSymbole(i_iIndex, i_jIndex);
            return isSymbolePlaced;
        }
        public int WinningStatus()
        {
            bool isGameOver = m_Board.IsGameOver();

        }
    }
}
