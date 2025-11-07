namespace _05_MinMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int starter = rd.Next(0, 2);

            TicTacToe ttt = new TicTacToe();
            char player = ' ';
            if (starter == 0) player = 'O';
            else player = 'X';

            Console.WriteLine(ttt);

            while (!ttt.Full())
            {
                int position = -1;
                if (player == 'X')
                {
                    Console.Write($"Place {player} on: ");
                    position = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    position = ttt.SmartPlayer();
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
    }
}
