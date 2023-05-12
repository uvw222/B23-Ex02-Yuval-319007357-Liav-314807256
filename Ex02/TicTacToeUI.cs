using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex02
{
    class TicTacToeUI
    { 
        private TicTacToeLogics m_Logics = null;
        public void Game()
        {
            bool isQuit = false;
            InitializeGame();
            while (!isQuit)//!=Q
            {
                while (!IsGameOver() && !isQuit)
                {
                    PrintBoard();
                    isQuit = PlayersChoice();
                }
                NewGame();
                //print meanwhile summary between games
            }

        }

        void InitializeGame()
        {
            Console.WriteLine("Please choose size N of board(N X N) :");
            int sizeOfBoard = int.Parse(Console.ReadLine());
            Console.WriteLine("How many player are playing? \nenter 1 or 2:");
            int numOfPlayers = int.Parse(Console.ReadLine());
            //request size and num of players, print and local veriabls
            //validation function
            m_Logics = new TicTacToeLogics(sizeOfBoard, numOfPlayers);
            
        }

        private void PrintBoard()
        {
            TicTacToeBoard board = m_Logics.BoardState;//-gets the array 
            int size = board.Size;
            CellValue[,] cells = board.BoardState;

            // todo -- divide it to methods!!!!
            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col+1.ToString().PadLeft(2)} ");
            }
            Console.WriteLine();

            Console.Write("  ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("===");
            }
            Console.WriteLine();

            for (int row = 0; row < size; row++)
            {
                Console.Write($"{row+1.ToString().PadLeft(2)}|");
                for (int col = 0; col < size; col++)
                {
                    Console.Write($" {cells[row, col].ToString().PadLeft(2)}|");
                }
                Console.WriteLine();

                Console.Write("  ");
                for (int col = 0; col < size; col++)
                {
                    Console.Write("===");
                }
                Console.WriteLine();
            }
        }
        private bool PlayersChoice()
        {
            bool turnOver = false, quit = false;
            Player currPlayer = m_Logics.CurrentPlayer;

            while(!turnOver)
            {
                if (currPlayer.IsBot)
                {
                    turnOver = m_Logics.PlayersMove(1, 2); // todo make it randommmmm!!!
                }
                else
                {
                    //todo -- divide to methods!!!!!!!!!
                    //its just dirty needs to make methods that do the same work without copy of code!
                    Console.WriteLine("Please enter the i box indexes:");
                    string input = Console.ReadLine();
                    if (input == "Q")
                    {
                        quit = true;
                        break;
                    }
                    int i = int.Parse(input);
                    Console.WriteLine("Please enter the j box indexes:");
                    input = Console.ReadLine();
                    if (input == "Q")
                    {
                         quit = true;
                        break;
                    }
                    int j = int.Parse(input);
                    turnOver = m_Logics.PlayersMove(i, j); 
                }
            }
            return quit;
            //validate i, j - if Q than return true
            //bool ....Logics.PlayersMove(i,j);
            //validate the location in the matrix
            //return false;
        }
        private void NewGame()
        {
            m_Logics.ResetGame();
        }
        private bool IsGameOver()
        {
            CellValue winnerSymbole;
            bool isGameOver = m_Logics.WinningStatus(out winnerSymbole);
            if(isGameOver)
            {
                if(winnerSymbole == CellValue.Empty)
                {
                    Console.WriteLine("Its a tie");
                }
                Console.WriteLine($"Congrats to {winnerSymbole.ToString()} the winner!");
            }
            return isGameOver;
        
        }
    }
}
