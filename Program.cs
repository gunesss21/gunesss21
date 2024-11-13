using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        static int player = 1; 
        static int choice; 
        static int flag = 0; 

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X | Player 2: O");
                Console.WriteLine();
                Board();

                
                player = (player % 2) == 0 ? 2 : 1;
                Console.WriteLine("Player {0}, enter a position (0-8): ", player);

            
                bool validInput = int.TryParse(Console.ReadLine(), out choice);
                if (!validInput || choice < 0 || choice > 8)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 8.");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }

              
                if (board[choice] != 'X' && board[choice] != 'O')
                {
                    board[choice] = player == 1 ? 'X' : 'O';
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry, the position {0} is already taken by {1}.", choice, board[choice]);
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        static void Board()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static int CheckWin()
        {
          
          
            int[,] winCombinations = {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, 
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, 
                {0, 4, 8}, {2, 4, 6}             
            };

           
            for (int i = 0; i < winCombinations.GetLength(0); i++)
            {
                int a = winCombinations[i, 0];
                int b = winCombinations[i, 1];
                int c = winCombinations[i, 2];

                if (board[a] == board[b] && board[b] == board[c])
                {
                    return 1; 
                }
            }

          
            foreach (var position in board)
            {
                if (position != 'X' && position != 'O')
                {
                    return 0;
                }
            }

            return -1; 
        }
    }
}
