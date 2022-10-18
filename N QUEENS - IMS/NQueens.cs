using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace N_QUEENS___IMS
{
    class NQueens
    {
        public char[,] Board { get; set; }

        public NQueens(int n)
        {
            /*Board = new char[,] {   { 'Q', ' ', ' ', ' ' },
                                    { ' ', ' ', 'Q', ' ' },
                                    { ' ', ' ', ' ', ' ' },
                                    { ' ', 'Q', ' ', ' ' } };*/
            Board = new char[n,n];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = '-';
                }
            }
        }

        private bool Check(int row, int col)
        {
            //rij checken
            for (int i = 0; i < col; i++)
            {
                if (Board[row, i] == 'Q') return false;
            }

            //kolom checken
            for (int i = 0; i < row; i++)
            {
                if (Board[i,col] == 'Q') return false;
            }

            //diagonaal checken
            for (int i = 0; i <= Math.Min(row, col); i++)
            {
                if (Board[row - i, col - i] == 'Q') return false ;
            }

            for (int i = 0; row +i < Board.GetLength(0) && col-i >=0 ; i++)
            {
                if (Board[row + i, col - i] == 'Q') return false;
            }
            return true;
        }

        public bool Solve(int col=0)
        {
            if (col == Board.GetLength(0)) return true;

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (this.Check(i, col))
                {
                    Board[i, col] = 'Q';
                    Console.WriteLine(this.ToString());
                    if (Solve(col + 1)) return true;
                    Board[i, col] = '-';
                    Console.WriteLine(this.ToString());

                }
            }
            return false;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    s += Board[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }


    }
}
