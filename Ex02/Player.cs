using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Player
    {
        private readonly CellValue r_Symbole;
        private int m_Score = 0;
        private readonly bool r_IsBot;

        public void IncrementScore()
        {
            m_Score++;  
        }
        public Player(CellValue i_Symbole, bool i_IsBot)
        {
            this.r_Symbole = i_Symbole;
            this.r_IsBot = i_IsBot;
        }

        public bool IsBot
        {
            get { return r_IsBot; }
        }
        public CellValue Symbole
        {
            get
            {
                return r_Symbole;
            }
        }

        
    }
}
