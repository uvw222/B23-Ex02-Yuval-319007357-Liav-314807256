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
            if (GetCell(i_iIndex, i_jIndex) == CellValue.Empty)
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

        public bool IsPlaceOnBoard()
        {
            bool isNotFull = false;
            foreach(CellValue cell in m_Board)
            {
                if (cell == CellValue.Empty)
                {
                    isNotFull = true;
                }
            }
            return isNotFull;
        }

        // TODOOOOO - make this method shorter
        public CellValue GetWinner()
        {
            CellValue symbolOfWinner = CellValue.Empty;
            bool isWinner = false;
            int counterX = 0, counterO = 0;

            // Check rows
            for (int i = 0; i < m_size && !isWinner; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    if (m_Board[i, j] == CellValue.X)
                    {
                        counterX++;
                    }
                    else if (m_Board[i, j] == CellValue.O)
                    {
                        counterO++;
                    }
                }
                if (counterO == m_size)
                {
                    isWinner = true;
                    symbolOfWinner = CellValue.X;
                }
                else if (counterX == m_size)
                {
                    isWinner = true;
                    symbolOfWinner = CellValue.O;
                }
                counterO = counterX = 0;
            }

            // Check diagonal left to right
            for (int i = 0; i < m_size && !isWinner; i++)
            {

                if (m_Board[i, i] == CellValue.X)
                {
                    counterX++;
                }
                else if (m_Board[i, i] == CellValue.O)
                {
                    counterO++;
                }
            }
            if (counterO == m_size)
            {
                isWinner = true;
                symbolOfWinner = CellValue.O;
            }
            else if (counterX == m_size)
            {
                isWinner = true;
                symbolOfWinner = CellValue.X;
            }
            counterO = counterX = 0;

            //check diagonal right to left
            for (int i = m_size-1; i >= 0 && !isWinner; i--)
            {

                if (m_Board[i, i] == CellValue.X)
                {
                    counterX++;
                }
                else if (m_Board[i, i] == CellValue.O)
                {
                    counterO++;
                }
            }
            if (counterO == m_size)
            {
                isWinner = true;
                symbolOfWinner = CellValue.O;
            }
            else if (counterX == m_size)
            {
                isWinner = true;
                symbolOfWinner = CellValue.X;
            }
            counterO = counterX = 0;


            //check colomns
            for (int i = 0; i < m_size && !isWinner; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    if (m_Board[j, i] == CellValue.X)
                    {
                        counterX++;
                    }
                    else if (m_Board[j, i] == CellValue.O)
                    {
                        counterO++;
                    }
                }
                if (counterO == m_size)
                {
                    isWinner = true;
                    symbolOfWinner = CellValue.X; 
                }
                else if (counterX == m_size)
                {
                    isWinner = true;
                    symbolOfWinner = CellValue.O;
                }
                counterO = counterX = 0;
            }

            // No winner yet
            return symbolOfWinner;
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


