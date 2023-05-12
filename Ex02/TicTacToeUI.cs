using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex02
{
    class TicTacToeUI
    { 
        TicTacToeLogics m_Logics;
        public void Game()
        {
            bool isQuit=false;
            InitializeGame();
            while (!isQuit)//!=Q
            {
                while (!this.IsGameOver() && !isQuit)
                {
                    this.PrintBoard(m_Logics.);
                    isQuit = this.PlayersChoice();
                }
                this.NewGame();
                //print meanwhile summary between games
            }

        }

        static void InitializeGame()
        { 
            //request size and num of players, print and local veriabls
            //validation function
            m_Logics = new TicTacToeLogics(sizeOfBoard, numOfPlayers);
            
        }
        private void PrintBoard()
        {
            CellValue[,] board = m_Logics.BoardState;//-gets the array 
            int size = m_Logics.Size;
            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col.ToString().PadLeft(2)} ");
            }
            Console.WriteLine();

            Console.Write("  ");
            for (int col = 0; col < _size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine();

            for (int row = 0; row < _size; row++)
            {
                Console.Write($"{row.ToString().PadLeft(2)}|");
                for (int col = 0; col < _size; col++)
                {
                    Console.Write($" {_cells[row, col].ToString().PadLeft(2)}|");
                }
                Console.WriteLine();

                Console.Write("  ");
                for (int col = 0; col < _size; col++)
                {
                    Console.Write("---");
                }
                Console.WriteLine();
            }
        }
        private bool PlayersChoice()
        {
            Player currPlayer = m_Logics.
            Console.WriteLine("Please enter the i box indexes:");
            int i = int.Parse(System.Console.ReadLine());
            Console.WriteLine("Please enter the j box indexes:");
            int j = int.Parse(System.Console.ReadLine());
            //validate i, j - if Q than return true
            //bool ....Logics.PlayersMove(i,j);
            //validate the location in the matrix
            //return false;
        }
        private void NewGame()
        {
            //...Logics.ResetGame();
        }
        private bool IsGameOver()
        {

            //if 1 or 2 or 3 game over - 1= player one, 2-player two, 3=tie
            //if 0 return still playing
            //return ...Logics.WinningStatus();
            printwinner();
        
        }
    }
}
