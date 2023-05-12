using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public enum CellValue
    {
        Empty,
        X,
        O
    }

    internal class TicTacToeBoard
    {
        private CellValue[,] m_Board;
        private int m_size;
        

        public TicTacToeBoard(int i_size)
        {
            m_size = i_size;
            m_Board = new CellValue[m_size, m_size]; 
            ResetBoard(); 
        }

        // Method to reset the board to empty cells
        public void ResetBoard()
        {
            for (int i = 0; i < m_size; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    m_Board[i, j] = CellValue.Empty;
                }
            }
        }

        public bool PlaceSymbol(CellValue i_symbol, int i_iIndex, int i_jIndex)
        {
            bool isPlaced = false;
            if(GetCell(i_iIndex, i_jIndex) == CellValue.Empty)
            {
                m_Board[i_iIndex, i_jIndex] = i_symbol;
                isPlaced = true;
            }
            else
            {
                isPlaced = false;
            }

            return isPlaced;
        }

        public CellValue GetCell(int i_iIndex, int i_jIndex)
        {
            return m_Board[i_iIndex, i_jIndex];
        }

        public CellValue[,] BoardState
        {
            get
            { 
                return m_Board;
            }
        }
    }

}
