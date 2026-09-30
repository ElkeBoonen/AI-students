namespace MiniMax
{
    // X = computer (MAX), O = speler (MIN)
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
 
        public int SmartPlayer()
        {
            // TODO
            //return NaivePlayer();
            int best = Int32.MinValue;
            int bestposition = -1;
            foreach(int position in EmptyPlaces())
            {
                DoMove(position, 'X');
                int score = MinMax(false);
                UndoMove(position);
                if (score > best)
                {
                    best = score;
                    bestposition = position;
                }
            }
            return bestposition;


        }
 
        private int MinMax(bool isMax)
        {
            /* functie minimax(knoop, diepte, isMAX):
                als diepte = 0 of knoop is terminaal:
                    geef score(knoop) terug
                als isMAX:
                    beste = -∞
                    voor elk kind van knoop:
                    beste = max(beste, minimax(kind, diepte-1, ONWAAR))
                    geef beste terug
                anders:
                    beste = +∞
                    voor elk kind van knoop:
                    beste = min(beste, minimax(kind, diepte-1, WAAR))
                    geef beste terug*/
            if (Wins('X')) return +1;
            if (Wins('O')) return -1;
            if (Full()) return 0;
            
            if (isMax)
            {
                int best = Int32.MinValue;
                foreach(int position in EmptyPlaces())
                {
                    DoMove(position, 'X');
                    int score = MinMax(false);
                    UndoMove(position);
                    best = Math.Max(best, score);
                }
                return best;
            }
            else
            {
                int best = Int32.MaxValue;
                foreach(int position in EmptyPlaces())
                {
                    DoMove(position, 'O');
                    int score = MinMax(true);
                    UndoMove(position);
                    best = Math.Min(best, score);
                }
                return best;
            }
        }
 
        private int Score()
        {
            // TODO
            return 0;
        }
 
        internal int NaivePlayer()
        {
            Random rd = new Random();
            List<int> list = EmptyPlaces();
            return list[rd.Next(0, list.Count)];
        }
 
        private void DoMove(int position, char player)
        {
            _board[position] = player;
        }
 
        private void UndoMove(int position)
        {
            _board[position] = position.ToString()[0];
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
 
        internal bool Full()
        {
            return EmptyPlaces().Count == 0;
        }
 
        internal bool IsFree(int position)
        {
            return position >= 0 && position < _board.Length && _board[position] == position.ToString()[0];
        }
 
        internal void Place(char player, int position)
        {
            if (IsFree(position)) _board[position] = player;
        }
 
        internal bool Wins(char player)
        {
            int[,] lines =
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                {0, 4, 8}, {2, 4, 6}
            };
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                if (_board[lines[i, 0]] == player &&
                    _board[lines[i, 1]] == player &&
                    _board[lines[i, 2]] == player) return true;
            }
            return false;
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
    }
}