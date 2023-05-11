using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class TicTacToeBoard
    {
        private Box[,] m_Board;
        private int m_size;
        private struct Box  // to check how to implemnt correctly
        {
            char symbol;
            bool taken;

            public char Symbol
            {
                get
                {
                    return symbol;
                }
                set
                {
                    if (value != ' ')
                    {
                        taken = true;
                    }
                    symbol = value;
                }
            }
            public bool Taken
            {
                get
                {
                    return taken;
                }
            }
        }

        public TicTacToeBoard(int i_size)
        {
            m_size = i_size;
            m_Board = new Box[m_size, m_size]; 
            ResetBoard(); 
        }

        // Method to reset the board to empty cells
        public void ResetBoard()
        {
            for (int i = 0; i < m_size; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    m_Board[i, j].Symbol = ' ';
                }
            }
        }

        public Box[,] BoardState
        {
            get
            { 
                return m_Board;
            }
        }
    }

}
