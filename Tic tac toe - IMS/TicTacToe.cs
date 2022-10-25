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

        }

        private List<int> EmptyPlaces()
        {
       
        }

        public bool Wins(char player)
        {
         
        }

        public bool Place(char player, int position)
        {
          
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

