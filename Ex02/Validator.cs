using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public static class Validator
    {
        public static bool TryAndGetValidBoardSize(string i_sizeOfBoardInput, out int o_sizeOfBoard)
        {
            return int.TryParse(i_sizeOfBoardInput, out o_sizeOfBoard) && (o_sizeOfBoard >= 3 && o_sizeOfBoard <= 9);
        }
        public static void ValidateBoardSize(ref int io_boardSize)
        {
            bool isValidSizeNumber = false;
            while (!isValidSizeNumber)
            {
                Console.WriteLine("Please choose size N of board(N X N) :");
                string sizeOfBoardInput = Console.ReadLine();
                if (TryAndGetValidBoardSize(sizeOfBoardInput, out io_boardSize))
                {
                    isValidSizeNumber = true;
                }
                else
                {
                    Console.WriteLine(@"The board size you requested is invalid. Please try again.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }
        public static bool TryAndGetValidNumOfPlayers(string i_numOfPlayersInput, out int o_numOfPlayers)
        {
            return int.TryParse(i_numOfPlayersInput, out o_numOfPlayers) && (o_numOfPlayers >= 1 && o_numOfPlayers <= 2);
        }
        public static void ValidatNumOfPlayers(ref int io_numOfPlayers)
        {
            bool isValidNumOfPlayers = false;
            while (!isValidNumOfPlayers)
            {
                Console.WriteLine(@"How many players are playing?
enter 1 or 2:");
                string numOfPlayersInput = Console.ReadLine();
                if (TryAndGetValidNumOfPlayers(numOfPlayersInput, out io_numOfPlayers))
                {
                    isValidNumOfPlayers = true;
                }
                else
                {
                    Console.WriteLine(@"The number of players you requested is invalid. Please try again.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }
        public static bool TryAndGetValidIndexes(string i_indexInput, out int o_index, int i_sizeOfBoard)
        {
            return int.TryParse(i_indexInput, out o_index) && (o_index>=1 && o_index <= i_sizeOfBoard);
        }
        public static void ValidateIndexes(ref string io_input, ref int io_indexI, ref int io_indexJ, string i_playerName, int i_boardSize)
        {
            bool isValidIndexI = false, isValidIndexJ = false;
            while (!(isValidIndexI && isValidIndexJ))
            {
                Console.WriteLine($"{i_playerName} Please enter the desired row number:");
                io_input = Console.ReadLine();

                if (io_input != 'Q'.ToString())
                {
                    if (TryAndGetValidIndexes(io_input, out io_indexI, i_boardSize))
                    {
                        isValidIndexI = true;
                    }
                    else
                    {
                        isValidIndexI = false;
                    }
                }
                else
                {
                    break;
                }


                Console.WriteLine($"{i_playerName} Please enter the desired column number:");
                io_input = Console.ReadLine();
                if (io_input != 'Q'.ToString())
                {
                    if (TryAndGetValidIndexes(io_input, out io_indexJ, i_boardSize))
                    {
                        isValidIndexJ = true;
                    }
                    else
                    {
                        isValidIndexJ = false;
                    }
                }
                else
                {
                    break;
                }

                if (!(isValidIndexI && isValidIndexJ))
                {
                    Console.WriteLine(@"The indexes you requested are invalid. Please try again.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
            io_indexI--;
            io_indexJ--;


        }
    }
}
