using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tic_tac_toe
{
    /// <summary></summary>
    class TicTacToe
    {
        char[] _board;

        public TicTacToe()
        {
            _board = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        }

        public bool Full()
        {
            if (EmptyPlaces().Count == 0) return true;
            return false;
        }

        private List<int> EmptyPlaces()
        {
            List<int> empty = new List<int>();
            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i] != 'X' && _board[i] != 'O') empty.Add(i);
            }
            return empty;
        }

        public bool Wins(char player)
        {
            //horizontal lines
            if (_board[0] == player && _board[1] == player && _board[2] == player) return true;
            if (_board[3] == player && _board[4] == player && _board[5] == player) return true;
            if (_board[6] == player && _board[7] == player && _board[8] == player) return true;

            //vertical lines
            if (_board[0] == player && _board[3] == player && _board[6] == player) return true;
            if (_board[1] == player && _board[4] == player && _board[7] == player) return true;
            if (_board[2] == player && _board[5] == player && _board[8] == player) return true;

            //diagonals
            if (_board[0] == player && _board[4] == player && _board[8] == player) return true;
            if (_board[2] == player && _board[4] == player && _board[6] == player) return true;

            return false;
        }

        public bool Place(char player, int position)
        {
            //if (_board[position]!='X' && _board[position]!='0')
            if (EmptyPlaces().Contains(position))
            {
                _board[position] = player;
                return true;
            }
            return false;
        }

        public int StupidPlayer()
        { 
            Random rd = new Random();
            int index = rd.Next(0, EmptyPlaces().Count);
            return EmptyPlaces()[index];
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

        private int MinMax(bool isMax)
        {
            //return score
            
            //BASE CASES
            if (Wins('O')) return 1;
            if (Wins('X')) return -1;
            if (Full()) return 0;

            //RECURSIVE CASES
            if (isMax)
            {
                int score = int.MaxValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'X';
                    score = Math.Min(MinMax(!isMax), score);
                    _board[position] = c;
                }
                return score;
            }
            else
            {
                int score = int.MinValue;
                foreach (int position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'O';
                    score = Math.Max(MinMax(!isMax), score);
                    _board[position] = c;
                }
                return score;
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


     

    }
}

