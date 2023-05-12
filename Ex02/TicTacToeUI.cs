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
                GameSummery();
                isQuit = NewGame();
                //print meanwhile summary between games
            }

        }

        private void GameSummery()
        {
            Console.WriteLine($"Player 1 Score is:{m_Logics.GetPlayerBySymbole(CellValue.X).Score}");
            Console.WriteLine($"Player 2 Score is:{m_Logics.GetPlayerBySymbole(CellValue.O).Score}");
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

            Ex02.ConsoleUtils.Screen.Clear();
            // todo -- divide it to methods!!!!
            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{(col+1).ToString().PadLeft(2)} ");
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
                Console.Write($"{(row+1).ToString().PadLeft(2)}|");
                for (int col = 0; col < size; col++)
                {
                    Console.Write($" {ToString(cells[row, col]).PadLeft(1)}|");
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
            string playerName = currPlayer.ToString();
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
                    Console.WriteLine($"{playerName} Please enter the i box indexes:");
                    string input = Console.ReadLine();
                    if (input == "Q")
                    {
                        quit = true;
                        break;
                    }
                    int i = int.Parse(input) - 1;
                    Console.WriteLine($"{playerName}Please enter the j box indexes:");
                    input = Console.ReadLine();
                    if (input == "Q")
                    {
                         quit = true;
                        break;
                    }
                    int j = int.Parse(input) - 1;
                    turnOver = m_Logics.PlayersMove(i, j); 
                }
            }
            return quit;
            //validate i, j - if Q than return true
            //bool ....Logics.PlayersMove(i,j);
            //validate the location in the matrix
            //return false;
        }
        private bool NewGame()
        {
            bool isQuit = false;
            m_Logics.ResetGame();
            Console.WriteLine("Do you want to continue playing? (yes|no)");
            if(Console.ReadLine() == "yes")
            {
                Console.WriteLine("Let's Go");
            }
            else
            {
                isQuit = true;
                Console.WriteLine("Bye..");
            }
            return isQuit;
        }
        private bool IsGameOver()
        {
            CellValue winnerSymbole;
            bool isGameOver = m_Logics.WinningStatus(out winnerSymbole);
            if (isGameOver)
            {
                PrintBoard();
                if (winnerSymbole == CellValue.Empty)
                {
                    Console.WriteLine("Its a tie");
                }
                else
                {
                    Console.WriteLine($"Congrats to {m_Logics.GetPlayerBySymbole(winnerSymbole).ToString()} the winner!");
                }
            }
            return isGameOver;
        
        }
        public static string ToString(CellValue value)
        {
            switch(value)
            {
                case CellValue.Empty:
                    return " ";
                case CellValue.X:
                    return "X";
                case CellValue.O:
                    return "O";
                default:
                    return value.ToString();
            }
        }
    }
}
