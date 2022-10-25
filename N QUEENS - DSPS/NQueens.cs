using System;
using System.Collections.Generic;
using System.Text;

namespace N_QUEENS___DSPS
{
    class NQueens
    {
        private int[,] _board;

        public NQueens(int dimension)
        {
            _board = new int[dimension, dimension];

            //_board = new int[,]{ { 1,0,0,0 },
            //                     { 0,0,0,0 },
            //                     { 0,0,0,0 },
            //                     { 0,0,0,0}};
        }

        private bool QueenCheck(int row, int col)
        {
            int sumCol=0, sumRow =0, sumDiaUp = 0, sumDiaDown = 0;

            //checking row
            for (int i = col; i >= 0; i--)
            {
                sumRow += _board[row, i];
            }

            //checking col
            for (int i = row; i >=0; i--)
            {
                sumCol += _board[i, col];
            }

            for (int i = 0; row-i >= 0 && col-i >=0 ; i++)
            {
                sumDiaUp += _board[row - i, col - i];
            }

            for (int i = 0; row+i < _board.GetLength(0) &&  col-i >=0; i++)
            {
                sumDiaDown += _board[row + i, col - i]; 
            }

            //Console.WriteLine($"({row},{col}) --> row {sumRow} col {sumCol} diaUp {sumDiaUp} diaDown {sumDiaDown}");

            if (sumRow == 0 && sumCol == 0 && sumDiaUp == 0 && sumDiaDown == 0) return true;
            return false;
        }

        public bool Solve(int col = 0) 
        {
            if (col == _board.GetLength(0)) return true;

            Console.WriteLine(this.ToString());

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (QueenCheck(i, col))
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
            string s = "";
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    s += _board[i, j] + " ";
                }
                s += "\n";
            }

            return s;
        }
    }
}
