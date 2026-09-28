
using MiniMax;


TicTacToe ttt = new TicTacToe();
char player = 'X';

Console.WriteLine(ttt);

while (!ttt.Full())
{
    int position;
    if (player == 'X')
    {
        Console.Write("Plaats X op vakje: ");
        position = Convert.ToInt32(Console.ReadLine());
        if (!ttt.IsFree(position)) continue; // vakje bezet? --> terug naar boven
    }
    else
    {
        position = ttt.SmartPlayer();
    }

    ttt.Place(player, position);
    Console.WriteLine(ttt);

    if (ttt.Wins(player))
    {
        Console.WriteLine($"{player} wint!");
        return;
    }

    if (player == 'X') player = 'O';
    else player = 'X';
}

Console.WriteLine("Gelijkspel!");
