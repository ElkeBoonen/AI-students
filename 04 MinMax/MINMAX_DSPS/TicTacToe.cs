using System;


namespace MINMAX_DSPS
{
    internal class TicTacToe
    {
        char[] _board = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };

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
            if (_board[0] == player && _board[1] == player && _board[2] == player) return true;
            if (_board[0] == player && _board[3] == player && _board[6] == player) return true;
            if (_board[0] == player && _board[4] == player && _board[8] == player) return true;

            if (_board[1] == player && _board[4] == player && _board[7] == player) return true;
            if (_board[2] == player && _board[5] == player && _board[8] == player) return true;
            if (_board[2] == player && _board[4] == player && _board[6] == player) return true;

            if (_board[3] == player && _board[4] == player && _board[5] == player) return true;
            if (_board[6] == player && _board[7] == player && _board[8] == player) return true;

            return false;
        }

        internal int NaivePlayer()
        {
            Random r = new Random();
            int position = r.Next(EmptyPlaces().Count);
            return EmptyPlaces()[position];

        }

        internal int SmartPlayer()
        {
            int bestPosition = 0;
            int bestScore = Int32.MinValue;

            foreach (int position in EmptyPlaces())
            { 
                char c = _board[position];
                _board[position] = 'O';
                int score = MinMax(true);
                _board[position] = c;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestPosition = position;
                } 
            }
            return bestPosition;
        }

        private int MinMax(bool isMaximizing)
        {
            if (Wins('O')) return 1;
            if (Wins('X')) return -1;
            if (Full()) return 0;

            /*if maximizingPlayer then
                value := −∞
                for each child of node do
                        value:= max(value, minimax(child, depth − 1, FALSE))
                return value
            else (*minimizing player *)
                value:= +∞
                for each child of node do
                        value:= min(value, minimax(child, depth − 1, TRUE))
                return value*/

            if (isMaximizing)
            {
                int value = Int32.MaxValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'X';
                    value = Math.Min(MinMax(false), value);
                    _board[position] = c;
                }
                return value;
            }
            else
            {
                int value = Int32.MinValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'O';
                    value = Math.Max(MinMax(true), value);
                    _board[position] = c;
                }
                return value;
            }
        }


    }
}
