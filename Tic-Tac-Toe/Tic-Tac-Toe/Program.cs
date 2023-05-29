using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using RainbowText;

namespace TIC_TAC_TOE
{
    class Game
    {
        private char[,] board = new char[3, 3];
        private char player1;
        private char player2;
        private int currentPlayer = 0;

        static void Main()
        {
            Game gameObj = new Game();
            gameObj.setGame();
            while (gameObj.move()) ;
        }

        private void setGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    board[i, y] = '.';
                    Console.ResetColor();
                }
            }

            Console.Write("Player 1 select 'x' or 'o': ");
            player1 = char.Parse(Console.ReadLine());
            while (player1 != 'x' && player1 != 'o')
            {
                Console.WriteLine("Your choice shoud be either 'x' or 'o'");
                player1 = char.Parse(Console.ReadLine());
            }
            player2 = (player1 == 'x') ? 'o' : 'x';
            Console.WriteLine($"Player 2 you are '{player2}'");
            createTitle();

            Board();

            //x -> 1 o -> -1;
            if (player1 == 'x')
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer = -1;
            }
        }

        void printPlayerMove(int x, int y)
        {

            Console.ResetColor();

            if (board[x, y] == 'x')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{board[x, y]}");
                Console.ResetColor();
            }
            else if (board[x, y] == 'o')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{board[x, y]}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{board[x, y]}");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        void Board()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("___________________");
            Console.WriteLine("|     |     |     |");
            Console.Write("|  "); printPlayerMove(0, 0); Console.Write("  |  "); printPlayerMove(0, 1); Console.Write("  |  "); printPlayerMove(0, 2); Console.Write("  |\n");
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.Write("|  "); printPlayerMove(1, 0); Console.Write("  |  "); printPlayerMove(1, 1); Console.Write("  |  "); printPlayerMove(1, 2); Console.Write("  |\n");
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.Write("|  "); printPlayerMove(2, 0); Console.Write("  |  "); printPlayerMove(2, 1); Console.Write("  |  "); printPlayerMove(2, 2); Console.Write("  |\n");
            Console.WriteLine("|_____|_____|_____|");
            Console.ResetColor();
        }

        void createTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"TIC-TAC-TOE");

            if (player1 == 'o')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Player 1 you are '{player1}'");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player 2 you are '{player2}'");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player 1 you are '{player1}'");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Player 2 you are '{player2}'");
                Console.ResetColor();

            }
        }

        bool move()
        {
            if (!endGame())
            {
                if (currentPlayer == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player 1 it is your turn!");
                    Console.ResetColor();
                }
                else if (currentPlayer == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player 2 it is your turn!");
                    Console.ResetColor();
                }

                //Entering rc:
                //row:
                Console.Write("Make a move. (1, 2 or 3)\nRow: ");
                int row = int.Parse(Console.ReadLine());
                while (row < 1 || row > 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Try again!");
                    Console.Write("Row: ");
                    row = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                row = row - 1;

                //column:
                Console.Write("Column: ");
                int column = int.Parse(Console.ReadLine());
                while (column < 1 || column > 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Try again!");
                    Console.Write("Column: ");
                    column = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                column = column - 1;

                if (board[row, column] == 'x' || board[row, column] == 'o')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("This scope is taken. Try another one!");
                    Console.ResetColor();
                    move();
                }
                else
                {
                    if (currentPlayer == -1)
                    {
                        board[row, column] = player2;
                        createTitle();
                        Board();
                        if (checkWin() == true)
                        {
                            return false;
                        }
                        currentPlayer = 1;
                    }
                    else
                    {
                        board[row, column] = player1;
                        createTitle();
                        Board();
                        if (checkWin() == true)
                        {
                            return false;
                        }
                        currentPlayer = -1;
                    }
                }

            }
            else
            {
                Console.WriteLine("There is no winner!");
                return false;
            }
            return true;
        }

        bool endGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[i, y] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        bool checkWin()
        {
            string won = (currentPlayer == 1) ? "Player 1 WON!" : "Player 2 WON!";
            Console.Write("\n");

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == 'x' && board[i, 1] == 'x' && board[i, 2] == 'x')
                {
                    RainBowText.PrintRainbowText(won);
                    return true;
                }
                else if (board[i, 0] == 'o' && board[i, 1] == 'o' && board[i, 2] == 'o')
                {
                    RainBowText.PrintRainbowText(won);
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == 'x' && board[1, i] == 'x' && board[2, i] == 'x')
                {
                    RainBowText.PrintRainbowText(won);
                    return true;
                }
                else if (board[0, i] == 'o' && board[1, i] == 'o' && board[2, i] == 'o')
                {
                    RainBowText.PrintRainbowText(won);
                    return true;
                }
            }

            //DIAGONAL:
            if (board[0, 0] == 'x' && board[1, 1] == 'x' && board[2, 2] == 'x')
            {
                RainBowText.PrintRainbowText(won);
                return true;
            }
            else if (board[0, 0] == 'o' && board[1, 1] == 'o' && board[2, 2] == 'o')
            {
                RainBowText.PrintRainbowText(won);
                return true;
            }
            else if (board[0, 2] == 'x' && board[1, 1] == 'x' && board[2, 0] == 'x')
            {
                RainBowText.PrintRainbowText(won);
                return true;
            }
            else if (board[0, 2] == 'o' && board[1, 1] == 'o' && board[2, 0] == 'o')
            {
                RainBowText.PrintRainbowText(won);
                return true;
            }
            return false;
        }
    }
}