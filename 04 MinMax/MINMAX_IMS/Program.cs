namespace MINMAX_IMS
{
    internal class Program
    {

        static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();

            Random random = new Random();
            char player = ' ';

            if (random.Next(2) == 1) player = 'X';
            else player = 'O';

            Console.WriteLine(ttt);

            while (!ttt.Full())
            {
                if (player == 'X')
                {
                    Console.Write($"Place {player} on: ");
                    int position = Convert.ToInt32(Console.ReadLine());
                    ttt.Place(player, position);
                }
                else
                {
                    int position = ttt.SmartPlayer();
                    ttt.Place(player, position);
                }

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


        //met 2 spelers
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
