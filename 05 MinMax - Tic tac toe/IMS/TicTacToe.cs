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

        private List<int> EmptyPlaces()
        {
            List<int> places = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != 'X' && board[i] != 'O') places.Add(i);
            }
            return places;
        }

        public bool Full()
        {
            if (EmptyPlaces().Count == 0) return true;
            return false;
        }

        public void Place(char player, int position)
        {
            if (position >= 0 && position < 9)
            {
                if (Char.IsDigit(board[position])) board[position] = player;
            }
        }

        public bool Wins(char player)
        {
            if (board[0] == board[1] && board[1] == board[2] && board[0] == player) return true;
            if (board[3] == board[4] && board[4] == board[5] && board[3] == player) return true;
            if (board[6] == board[7] && board[7] == board[8] && board[6] == player) return true;

            if (board[0] == board[3] && board[3] == board[6] && board[0] == player) return true;
            if (board[1] == board[4] && board[4] == board[7] && board[1] == player) return true;
            if (board[2] == board[5] && board[5] == board[8] && board[2] == player) return true;

            if (board[0] == board[4] && board[4] == board[8] && board[0] == player) return true;
            if (board[2] == board[4] && board[4] == board[6] && board[2] == player) return true;

            return false;
        }

        public int NaivePlayer()
        {
            Random random = new Random();
            int index = random.Next(0, EmptyPlaces().Count);
            return EmptyPlaces()[index];
        }

        public int SmartPlayer()
        {
            int bestPosition = 0;
            int bestScore = Int32.MinValue;

            foreach (int position in EmptyPlaces())
            {
                char c = board[position];
                board[position] = 'O';
                int score = MinMax(true);
                board[position] = c;

                if (score > bestScore)
                {
                    bestScore = score ;
                    bestPosition = position;
                }
            }
            return bestPosition;
        }

        private int MinMax(bool isMax)
        {
            if (Wins('X')) return -1;
            if (Wins('O')) return 1;
            if (Full()) return 0;

            if (isMax)
            {
                int score = Int32.MaxValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = board[position];
                    board[position] = 'X';
                    score = Math.Min(score,MinMax(false));
                    board[position] = c;
                }
                return score;
            }
            else
            {
                int score = Int32.MinValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = board[position];
                    board[position] = 'O';
                    score = Math.Max(MinMax(true),score) ;
                    board[position] = c;
                }
                return score;
            }
        }
    }
}