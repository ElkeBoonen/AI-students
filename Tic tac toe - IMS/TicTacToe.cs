using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Tic_tac_toe
{
    class TicTacToe
    {
        char[] _board;

        public TicTacToe()
        {
            _board = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        }

        public bool Full()
        {
            if (EmptyPlaces().Count > 0) return false;
            return true;
        }

        private List<int> EmptyPlaces()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i] != 'X' && _board[i] != 'O') list.Add(i);
            }
            return list;
        }

        public bool Wins(char player)
        {
            //rijen checken
            if (_board[0] == player && _board[1] == player && _board[2] == player) return true;
            if (_board[3] == player && _board[4] == player && _board[5] == player) return true;
            if (_board[6] == player && _board[7] == player && _board[8] == player) return true;

            //kolommen checken
            if (_board[0] == player && _board[3] == player && _board[6] == player) return true;
            if (_board[1] == player && _board[4] == player && _board[7] == player) return true;
            if (_board[2] == player && _board[5] == player && _board[8] == player) return true;

            //diagonalen checken
            if (_board[0] == player && _board[4] == player && _board[8] == player) return true;
            if (_board[6] == player && _board[4] == player && _board[2] == player) return true;
            
            return false;
        }

        public bool Place(char player, int position)
        {
            if (_board[position] != 'X' && _board[position] != 'O')
            {
                _board[position] = player;
                return true;
            }
            return false;
        }

        public int NaivePlayer()
        { 
            Random rd = new Random();
            List<int> list = EmptyPlaces();
            int index = rd.Next(0, list.Count);
            return list[index];
        }

        public int SmartPlayer()
        {
            int bestScore = int.MinValue;
            int bestPosition = EmptyPlaces()[0];

            foreach (var position in EmptyPlaces())
            {
                char c = _board[position];
                _board[position] = 'O';     //make the move
                int score = MinMax(true);   //call minmax
                _board[position] = c;       //undo the move

                if (score > bestScore)      //update best move
                {
                    bestPosition = position;
                    bestScore = score;
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

        public int MinMax(bool isMax)
        {
            //basecases!!
            //if depth = 0 or node is a terminal node then return the score of node
            if (Wins('O')) return 1;
            if (Wins('X')) return -1;
            if (Full()) return 0;

            if (isMax)
            {
                int best = int.MaxValue;
                foreach (var position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'X';     //make the move
                    best = Math.Min(MinMax(false), best);   //call minmax
                    _board[position] = c;
                }
                return best;
            }
            else
            {
                int best = int.MinValue;
                foreach (var position in EmptyPlaces())
                {
                    char c = _board[position];
                    _board[position] = 'O';     //make the move
                    best = Math.Max(MinMax(true), best);   //call minmax
                    _board[position] = c;
                }
                return best;
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

