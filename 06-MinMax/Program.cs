using System;

namespace _06_NietZoSlim
{
    class Program
    {

        static void Main(string[] args)
        {
            TicTacToe spel = new TicTacToe();
            spel.PrintBoard();

            char piece = 'X';

            char winner = '\0';

            /*while (!spel.Full() && !spel.Winner(out winner))
            {
                Console.Write("Make a move {0} (enter position): ", piece);
                int position = Convert.ToInt32(Console.ReadLine());
                spel.MakeMove(position, piece);
                spel.PrintBoard();

                if (piece == 'X') piece = 'O';
                else piece = 'X';
            }*/

            while (!spel.Full() && !spel.Winner(out winner))
            {
                Console.Write("Make a move {0} (enter position): ", piece);
                int position = Convert.ToInt32(Console.ReadLine());
                spel.MakeMove(position, piece);
                if (spel.Winner(out winner))
                {
                    spel.PrintBoard();
                    break;
                }
                spel.StupidComputer();
                spel.PrintBoard();
            }

            if (winner != '\0') Console.WriteLine("{0} is gewonnen!", winner);
            else Console.WriteLine("Gelijkspel");
        }
    }
}
