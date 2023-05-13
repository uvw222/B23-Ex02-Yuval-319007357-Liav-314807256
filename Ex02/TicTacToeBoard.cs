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
        public int Size
        {
            get
            {
                return m_size;
            }
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
        public bool PlaceSymbole(CellValue i_symbol, int i_iIndex, int i_jIndex)
        {
            bool isPlacedSuccessfully = false;
            if (GetCell(i_iIndex, i_jIndex) == CellValue.Empty)
            {
                m_Board[i_iIndex, i_jIndex] = i_symbol;
                isPlacedSuccessfully = true;
            }
            else
            {
                isPlacedSuccessfully = false;
            }

            return isPlacedSuccessfully;
        }
        public bool PlaceEmptySymbole(CellValue i_symbol, int i_iIndex, int i_jIndex)
        {
            bool isPlacedSuccessfully = false;
            if (GetCell(i_iIndex, i_jIndex) != CellValue.Empty)
            {
                m_Board[i_iIndex, i_jIndex] = i_symbol;
                isPlacedSuccessfully = true;
            }
            else
            {
                isPlacedSuccessfully = false;
            }

            return isPlacedSuccessfully;
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
        public CellValue GetWinner()
        {
            CellValue symbolOfWinner = CellValue.Empty;
            bool isWinner = false;
            int counterX = 0, counterO = 0;
            // Check rows
            CheckWinnInARow(ref isWinner, ref counterX, ref counterO, ref symbolOfWinner);
            //check columns
            CheckWinnInAColumn(ref isWinner, ref counterX, ref counterO, ref symbolOfWinner);
            // Check diagonal top-left to bottom-right
            CheckWinnCrossRightToLeft(ref isWinner, ref counterX, ref counterO, ref symbolOfWinner);
            //check diagonal top-right to bottom-left
            CheckWinnCrossLeftToRight(ref isWinner, ref counterX, ref counterO, ref symbolOfWinner);

            // X = x is the winner | O = o is the winner | Empty = no winner
            return symbolOfWinner;
        }
        private void CheckWinnInARow(ref bool io_isWinner, ref int io_counterX, ref int io_counterO, ref CellValue io_symbolOfWinner)
        {
            for (int i = 0; i < m_size && !io_isWinner; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    if (m_Board[i, j] == CellValue.X)
                    {
                        io_counterX++;
                    }
                    else if (m_Board[i, j] == CellValue.O)
                    {
                        io_counterO++;
                    }
                }
                if (io_counterO == m_size)
                {
                    io_isWinner = true;
                    io_symbolOfWinner = CellValue.X;
                }
                else if (io_counterX == m_size)
                {
                    io_isWinner = true;
                    io_symbolOfWinner = CellValue.O;
                }
                io_counterO = io_counterX = 0;
            }
        }
        private void CheckWinnCrossRightToLeft(ref bool io_isWinner, ref int io_counterX, ref int io_counterO, ref CellValue io_symbolOfWinner)
        {
            for (int i = 0; i < m_size && !io_isWinner; i++)
            {

                if (m_Board[i, i] == CellValue.X)
                {
                    io_counterX++;
                }
                else if (m_Board[i, i] == CellValue.O)
                {
                    io_counterO++;
                }
            }
            if (io_counterO == m_size)
            {
                io_isWinner = true;
                io_symbolOfWinner = CellValue.X;
            }
            else if (io_counterX == m_size)
            {
                io_isWinner = true;
                io_symbolOfWinner = CellValue.O;
            }
            io_counterO = io_counterX = 0;
        }
        private void CheckWinnCrossLeftToRight(ref bool io_isWinner, ref int io_counterX, ref int io_counterO, ref CellValue io_symbolOfWinner)
        {
            for (int i = m_size - 1; i >= 0 && !io_isWinner; i--)
            {

                if (m_Board[i, i] == CellValue.X)
                {
                    io_counterX++;
                }
                else if (m_Board[i, i] == CellValue.O)
                {
                    io_counterO++;
                }
            }
            if (io_counterO == m_size)
            {
                io_isWinner = true;
                io_symbolOfWinner = CellValue.X;
            }
            else if (io_counterX == m_size)
            {
                io_isWinner = true;
                io_symbolOfWinner = CellValue.O;
            }
            io_counterO = io_counterX = 0;
        }
        private void CheckWinnInAColumn(ref bool io_isWinner, ref int io_counterX, ref int io_counterO, ref CellValue io_symbolOfWinner)
        {
            for (int i = 0; i < m_size && !io_isWinner; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    if (m_Board[j, i] == CellValue.X)
                    {
                        io_counterX++;
                    }
                    else if (m_Board[j, i] == CellValue.O)
                    {
                        io_counterO++;
                    }
                }
                if (io_counterO == m_size)
                {
                    io_isWinner = true;
                    io_symbolOfWinner = CellValue.X;
                }
                else if (io_counterX == m_size)
                {
                    io_isWinner = true;
                    io_symbolOfWinner = CellValue.O;
                }
                io_counterO = io_counterX = 0;
            }
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


