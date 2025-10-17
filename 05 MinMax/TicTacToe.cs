
namespace _05_MinMax
{
    internal class TicTacToe
    {


        char[] _board = new char[9];



        public override string ToString()
        {
            string board = "     |     |      \n";
            board += $"  {_board[0]}  |  {_board[1]}  |  {_board[2]}\n";
            board += "_____|_____|_____ \n";
            board += "     |     |      \n";
            board += $"  {_board[3]}  |  {_board[4]}  |  {_board[5]}\n";
            board += "_____|_____|_____ \n";
            board += "     |     |      \n";
            board += $"  {_board[6]}  |  {_board[7]}  |  {_board[8]}\n";
            board += "     |     |      \n";
            return board;
        }

        internal bool Full()
        {
            throw new NotImplementedException();
        }

        internal void Place(char player, int position)
        {
            throw new NotImplementedException();
        }

        internal bool Wins(char player)
        {
            throw new NotImplementedException();
        }
    }
}