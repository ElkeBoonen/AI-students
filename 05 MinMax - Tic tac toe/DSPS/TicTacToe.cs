using System.Reflection.PortableExecutable;

namespace DSPS
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

        public bool Full()
        {
            bool check = true;
            foreach (char c in board)
            {
                if (Char.IsDigit(c)) check = false;
            }
            return check;
        }

        public void Place(char player, int position)
        {
            if (position >= 0 && position < board.Length)
                if (Char.IsDigit(board[position])) board[position] = player;   
        }

        public bool Wins(char player)
        {
            //rows
            if (board[0] == board[1] && board[1] == board[2] && board[2] == player) return true;
            if (board[3] == board[4] && board[4] == board[5] && board[5] == player) return true;
            if (board[6] == board[7] && board[7] == board[8] && board[8] == player) return true;

            //columns
            if (board[0] == board[3] && board[3] == board[6] && board[0] == player) return true;
            if (board[1] == board[4] && board[4] == board[7] && board[7] == player) return true;
            if (board[2] == board[5] && board[5] == board[8] && board[8] == player) return true;

            //diagonals
            if (board[0] == board[4] && board[4] == board[8] && board[0] == player) return true;
            if (board[2] == board[4] && board[4] == board[6] && board[6] == player) return true;

            return false;
        }

        private List<int> EmptyPlaces()
        { 
            List<int> list = new List<int> ();
            foreach (char c in board)
            {
                if (Char.IsDigit(c))
                {
                    list.Add(c - 48);
                }
            }
            return list;
        }

        internal int NaivePlayer()
        {
            Random random = new Random();
            int index = random.Next(0,EmptyPlaces().Count);
            return EmptyPlaces()[index];
        }
    }
}