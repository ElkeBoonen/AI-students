
namespace MINMAX_IMS
{
    internal class TicTacToe
    {
        private char[] _board = new char[] { '0', '1','2','3','4','5','6','7','8'};

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
            foreach (char c in _board)
            {
                if (Char.IsDigit(c)) return false;
            }
            return true;
        }

        private List<int> EmptyPlaces()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _board.Length; i++)
            {
                if (Char.IsDigit(_board[i])) list.Add(i);
            }
            return list;
        }

        internal void Place(char player, int position)
        {
            if (EmptyPlaces().Contains(position))
            { 
                _board[position] = player;
            }
        }

        internal bool Wins(char player)
        {
            //horizontaal
            if (_board[0] == player && _board[1]== player && _board[2]== player) return true;
            if (_board[3] == player && _board[4] == player && _board[5] == player) return true;
            if (_board[6] == player && _board[7] == player && _board[8] == player) return true;

            //verticaal
            if (_board[0] == player && _board[3] == player && _board[6] == player) return true;
            if (_board[1] == player && _board[4] == player && _board[7] == player) return true;
            if (_board[2] == player && _board[5] == player && _board[8] == player) return true;

            //diagonaal
            if (_board[0] == player && _board[4] == player && _board[8] == player) return true;
            if (_board[2] == player && _board[4] == player && _board[6] == player) return true;

            return false;
        }

        internal int NaivePlayer()
        {
            Random r = new Random();
            int index = r.Next(EmptyPlaces().Count);

            //Console.WriteLine(String.Join(" ", EmptyPlaces()));
            //Console.WriteLine(index);

            return EmptyPlaces()[index];
        }

        internal int SmartPlayer()
        {
            List<int> positions = new List<int>();
            int bestScore = Int32.MinValue;

            //Console.WriteLine(String.Join(" ", EmptyPlaces()));

            foreach (int position in EmptyPlaces())
            {
                char c = _board[position];
                _board[position] = 'O';
                int score = MinMax(false);
                _board[position] = c;

                if (score >= bestScore && score >= 0)
                { 
                    bestScore = score;
                    positions.Add(position);
                }
            }
            Random rd = new Random();
            Console.WriteLine(String.Join(" ", positions.ToArray()));
            return positions[rd.Next(positions.Count)];
        }

        private int MinMax(bool isMax)
        {
            if (Full()) return 0;
            if (Wins('X')) return -1;
            if (Wins('O')) return 1;

            if (isMax)
            {
                int score = Int32.MinValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'O';
                    score = Math.Max(MinMax(false), score);
                    _board[position] = c;
                }
                return score;
            }
            else //minimaliseren
            {
                int score = Int32.MaxValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'X';
                    score = Math.Min(MinMax(true), score);
                    _board[position] = c;
                }
                return score;
            }

        }
    }
}