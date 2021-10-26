using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax___DSPS
{
    class NQueens
    {
        int _N;
        int[,] _board;

        public NQueens(int N)
        {
            _N = N;
            _board = new int[N, N];
        }

        private bool IsSafe(int row, int col)
        {
            //checking row
            for (int i = 0; i < col; i++)
            {
                if (_board[row, i] == 1) return false; 
            }
            //no checking the column!!
            //diagonal left up
            for (int i = row, j = col ; i >= 0 && j >= 0 ; i--, j--)
            {
                if (_board[i, j] == 1) return false;
            }
            //diagonal left down
            for (int i = row, j = col; i < _N && j >= 0; i++, j--)
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
                if (IsSafe(i, col))
                {
                    _board[i, col] = 1;
                    if (Solve(col + 1)) return true;
                    _board[i, col] = 0;
                }
            }
            return false;
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

    }
}
