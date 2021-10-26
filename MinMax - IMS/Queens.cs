using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax___IMS
{
    class Queens
    {
        int[,] _board;
        int _N;

        public Queens(int N)
        {
            _N = N;
            _board = new int[_N, _N];
        }

        public override string ToString()
        {
            string s = "\n";
            for (int i = 0; i < _N; i++)
            {
                for (int j = 0; j < _N; j++)
                {
                    s += _board[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }

        private bool Check(int row, int col)
        {
            //rij links
            for (int i = 0; i < col ; i++)
            {
                if (_board[row, i] == 1) return false;
            }

            //links boven!!
            for (int i = row, j = col ; i >= 0 && j >=0 ; i--, j--)
            {
                if (_board[i, j] == 1) return false;
            }

            //links beneden
            for (int i = row, j = col;  i < _N && j >= 0; i++, j--)
            {
                if (_board[i, j] == 1) return false;
            }
            return true;
        }

        public bool Solve(int col)
        {
            Console.WriteLine(this.ToString());

            if (col == _N) return true;

            for (int i = 0; i < _N; i++)
            {
                if (Check(i, col))
                {
                    _board[i, col] = 1;
                    if (Solve(col + 1)) return true; 
                    _board[i, col] = 0;
                }
            }
            return false;
        }
    }
}
