using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace _06_NietZoSlim
{
    class TicTacToe
    {
        public char[] Board { get; }
        public TicTacToe()
        {
           Board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
        public bool Full()
        {
            foreach (var item in Board)
            {
                if ((item != 'X') && (item != 'O')) return false;
            }
            return true;
        }

        public bool Winner(out char winner)
        {
            winner = '\0';
            //horizontaal
            if ((Board[0] == Board[1]) && (Board[1] == Board[2])) winner = Board[0];
            if ((Board[3] == Board[4]) && (Board[4] == Board[5])) winner = Board[3];
            if ((Board[6] == Board[7]) && (Board[7] == Board[8])) winner = Board[6];

            //verticaal
            if ((Board[0] == Board[3]) && (Board[3] == Board[6])) winner = Board[0];
            if ((Board[1] == Board[4]) && (Board[4] == Board[7])) winner = Board[1];
            if ((Board[2] == Board[5]) && (Board[5] == Board[8])) winner = Board[2];

            //diagonaal
            if ((Board[0] == Board[4]) && (Board[4] == Board[8])) winner = Board[0];
            if ((Board[2] == Board[4]) && (Board[4] == Board[6])) winner = Board[2];

            if (winner != '\0') return true;
            return false;
        }

        public void MakeMove(int position, char c)
        {
            if ((c != 'X') && (c != 'O')) return;
            if ((Board[position-1] == 'X') || (Board[position-1] == 'O')) return;
            
            Board[position - 1] = c; 
        }

        public List<int> GetEmpty()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Board.Length; i++)
            {
                if ((Board[i] != 'X') && (Board[i] != 'O')) list.Add(i);
            }
            return list;
        }

        public void StupidComputer()
        {
            if (!Full())
            {
                Random rd = new Random();
                List<int> list = GetEmpty();
                int index = rd.Next(0, list.Count);
                Board[list[index]] = 'O';
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            Console.WriteLine(Board[0] + " | " + Board[1] + " | " + Board[2]);
            Console.WriteLine("----------");
            Console.WriteLine(Board[3] + " | " + Board[4] + " | " + Board[5]);
            Console.WriteLine("----------");
            Console.WriteLine(Board[6] + " | " + Board[7] + " | " + Board[8]);
            Console.WriteLine("");
        }
    }
}
