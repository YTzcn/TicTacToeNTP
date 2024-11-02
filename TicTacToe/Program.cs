using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

        private static char currentPlayer = 'X';

        public static void Main()
        {
            int turn = 0;
            bool gameEnded = false;

            Console.WriteLine("Tic Tac Toe Oyununa Hoşgeldiniz!");

            while (!gameEnded)
            {
                Console.Clear();
                DisplayBoard();

                Console.WriteLine($"\nOyuncu {currentPlayer}, bir pozisyon seçin (1-9): ");
                string input = Console.ReadLine();
                int position;

                // Kullanıcının geçerli bir giriş yapıp yapmadığını kontrol et
                if (!int.TryParse(input, out position) || position < 1 || position > 9)
                {
                    Console.WriteLine("Geçersiz pozisyon. Tekrar deneyin.");
                    continue;
                }

                // Kullanıcının pozisyonunu yerleştirmeyi dene
                if (!PlaceMark(position))
                {
                    Console.WriteLine("Pozisyon zaten dolu. Tekrar deneyin.");
                    continue;
                }

                turn++;
                gameEnded = CheckForWin() || turn == 9;

                if (!gameEnded)
                {
                    // Oyuncu değiştir
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }

            Console.Clear();
            DisplayBoard();

            if (CheckForWin())
            {
                Console.WriteLine($"\nTebrikler! Oyuncu {currentPlayer} kazandı!");
            }
            else
            {
                Console.WriteLine("\nOyun berabere bitti!");
            }
            Console.ReadLine();
        }

        private static void DisplayBoard()
        {
            Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2]);
        }

        private static bool PlaceMark(int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            // Pozisyon dolu mu kontrol et
            if (board[row, col] == 'X' || board[row, col] == 'O')
            {
                return false;
            }

            // Pozisyona oyuncunun işaretini yerleştir
            board[row, col] = currentPlayer;
            return true;
        }

        private static bool CheckForWin()
        {
            // Satırları, sütunları ve çaprazları kontrol et
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true;

                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true;
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            return false;
        }
    }
}
