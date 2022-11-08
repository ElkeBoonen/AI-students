namespace Tic_tac_toe
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
                int position = -1;
                if (player == 'X')
                {
                    Console.Write($"Place {player} on: ");
                    position = Convert.ToInt32(Console.ReadLine());
                }
                else position = ttt.SmartPlayer();
                //else position = ttt.StupidPlayer();

                ttt.Place(player, position);

                Console.WriteLine(ttt);
                if (ttt.Wins(player)) {
                    Console.WriteLine($"{player} is the winner!");
                    break;
                }

                if (player == 'X') player = 'O';
                else player = 'X';
            }
        }
    }
}