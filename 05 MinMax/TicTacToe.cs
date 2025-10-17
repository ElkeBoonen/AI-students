

namespace _05_MinMax
{
    internal class TicTacToe
    {


        char[] _board;

        public TicTacToe()
        {
            _board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                _board[i] = i.ToString()[0];
            }
        }



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
            //if (_board.Contains('\0')) return false;
            for (int i = 0; i < 9; i++)
            {
                if (_board[i] == i.ToString()[0]) return false;
            }
            return true;
        }

        internal int NaivePlayer()
        {
            Random rd = new Random();
            List<int> list = EmptyPlaces();
            int index = rd.Next(0, list.Count);
            return list[index];

        }

        public int SmartPlayer()
        {
            //return position 
            int bestPosition = 0, maxScore = int.MinValue;

            foreach (int position in EmptyPlaces())
            {
                char c = _board[position];
                _board[position] = 'O';
                int score = MinMax(true);
                _board[position] = c;

                if (maxScore < score)
                {
                    maxScore = score;
                    bestPosition = position;
                }
            }
            return bestPosition;
        }


        /*
         function minimax(node, depth, maximizingPlayer) is
            if depth = 0 or node is a terminal node then
                return the score of node
        
            if maximizingPlayer then
                value := −∞
                for each child of node do
                    value := max(value, minimax(child, depth − 1, FALSE))
                return value
            else (* minimizing player *)
                value := +∞
                for each child of node do
                    value := min(value, minimax(child, depth − 1, TRUE))
                return value
         */

        private int MinMax(bool minmax)
        {

            // werk verder af!
            if (minmax)
            {
                
            }
            else
            { 

            }
        }

        private List<int> EmptyPlaces()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i] == i.ToString()[0]) list.Add(i);
            }
            return list;
        }

        internal void Place(char player, int position)
        {
            if (position >= 0 && position < _board.Length)
            {
                if (_board[position] == position.ToString()[0])
                    _board[position] = player;
            }
        }

        internal bool Wins(char player)
        {
            //horizontaal
            if (_board[0] == player && _board[1] == player && _board[2]==player) return true;
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
    }
}