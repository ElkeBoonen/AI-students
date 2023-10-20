namespace IMS
{
    class TicTacToe
    {
        char[] board;

        public TicTacToe()
        {
            board = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        }

        public override string ToString()
        {
            string s = "     |     |      \n";
            s += $"  {board[0]}  |  {board[1]}  |  {board[2]}\n";
            s += "_____|_____|_____ \n";
            s += "     |     |      \n";
            s += $"  {board[3]}  |  {board[4]}  |  {board[5]}\n";
            s += "_____|_____|_____ \n";
            s += "     |     |      \n";
            s += $"  {board[6]}  |  {board[7]}  |  {board[8]}\n";
            s += "     |     |      \n";
            return s;
        }
    }
}