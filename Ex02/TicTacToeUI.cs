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
            int sizeOfBoard = 0, numOfPlayers = 0;
            Validator.ValidateBoardSize(ref sizeOfBoard);
            Validator.ValidatNumOfPlayers(ref numOfPlayers);
            m_Logics = new TicTacToeLogics(sizeOfBoard, numOfPlayers);
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
                    turnOver = m_Logics.ComputersMove();
                }
                else
                {
                    int i = -1, j = -1;
                    string input="";
                    Validator.ValidateIndexes(ref input, ref i, ref j, playerName, m_Logics.BoardState.Size);
                    if (input == "Q")
                    {
                        quit = true;//Award a point to the opponent due to the retirement of the current player
                        if (currPlayer== m_Logics.Player1)
                        {
                            m_Logics.Player2.IncrementScore();
                        }
                        else
                        {
                            m_Logics.Player1.IncrementScore();
                        }
                        break;
                    }
                    turnOver = m_Logics.PlayersMove(i, j); 
                }
            }
            return quit;
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
        private void PrintBoard()
        {
            TicTacToeBoard board = m_Logics.BoardState;//-gets the array 
            int size = board.Size;
            PrintFirstRowOfMatrix(size);
            for (int row = 0; row < size; row++)
            {
                PrintRowInIndexI(row, ref board);
            }
        }
        private void PrintRowInIndexI(int i_row, ref TicTacToeBoard io_board)
        {
            CellValue[,] cells = io_board.BoardState;
            Console.Write($"{(i_row + 1).ToString().PadLeft(2)}|");
            for (int col = 0; col < io_board.Size; col++)
            {
                Console.Write($"{ToString(cells[i_row, col]).PadLeft(3)}|");
            }
            Console.WriteLine();

            Console.Write("  ");
            for (int col = 0; col < io_board.Size; col++)
            {
                Console.Write("====");
            }
            Console.WriteLine();
        }
        private void PrintFirstRowOfMatrix(int i_size)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            for (int col = 0; col < i_size; col++)
            {
                Console.Write($"{(col + 1).ToString().PadLeft(4)}");
            }
            Console.WriteLine();
        }
    }
}
