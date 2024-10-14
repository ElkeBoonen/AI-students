namespace MINMAX_DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();
            char player = 'X';
            Console.WriteLine(ttt);

            while (!ttt.Full())
            {
                int position = ttt.SmartPlayer();
                if (player == 'X')
                {
                    Console.Write($"Place {player} on: ");
                    position = Convert.ToInt32(Console.ReadLine());
                }
                ttt.Place(player, position);
                Console.WriteLine(ttt);
                if (ttt.Wins(player))
                {
                    Console.WriteLine($"{player} is the winner!");
                    break;
                }

                if (player == 'X') player = 'O';
                else player = 'X';
            }
        }



        //2 player game
        /*static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();
            char player = 'X';
            Console.WriteLine(ttt);

            while (!ttt.Full())
            {
                Console.Write($"Place {player} on: ");
                int position = Convert.ToInt32(Console.ReadLine());
                ttt.Place(player, position);
                Console.WriteLine(ttt);
                if (ttt.Wins(player))
                {
                    Console.WriteLine($"{player} is the winner!");
                    break;
                }

                if (player == 'X') player = 'O';
                else player = 'X';
            }
        }*/
    }
}
