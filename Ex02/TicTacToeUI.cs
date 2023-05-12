using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex02
{
    class TicTacToeUI
    { 
        TicTacToeLogics m_logics;
        public void Game()
        {
            bool isQuit=false;
            InitializeGame();
            while (!isQuit)//!=Q
            {
                while (!this.IsGameOver() && !isQuit)
                {
                    this.PrintBoard();
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
            m_logics = new TicTacToeLogics(sizeOfBoard, numOfPlayers);
            
        }
        private void PrintBoard()
        {
            //....Logics.getBoardState(); -gets the array 
            //print matrix function
        }
        private bool PlayersChoice()
        {

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
