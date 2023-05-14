using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class TicTocToeAIMove
    {
        public int m_row;
        public int m_column;
        public int m_score;

        public TicTocToeAIMove(int i_row, int i_column, int i_score)
        {
            m_row = i_row;
            m_column = i_column;
            m_score = i_score;
        }
        public int Row
        {
            get
            {
                return m_row;
            }
        }
        public int Col
        {
            get
            {
                return m_column;
            }
        }
        public int Score
        {
            get
            {
                return m_score;
            }
        }
    }
}
