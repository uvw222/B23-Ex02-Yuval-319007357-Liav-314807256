using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex02
{
    class TicTacToeUI
    { 
        
        //TicTacToeLogics m_logics;

        public void Game()
        {
            bool isQuit;
            InitializeGame();
            while (!isQuit)//!=Q
            {
                while (!this.IsWinn() && !isQuit)
                {
                    this.PrintBoard();
                    isQuit = this.PlayersChoice();
                }
                this.NewGame();
            }

        }

        static void InitializeGame()
        {
            //size of board
            //how many players
            System.Console.ReadLine();
        }
        private void PrintBoard()
        {

        }
        private bool PlayersChoice()
        {

        }
        private void NewGame()
        {

        }
        private bool IsWin()
        {

        }
    }
}
