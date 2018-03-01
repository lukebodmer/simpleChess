using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 32);
            Console.WriteLine( "Welcome to Chess! Please input your moves as follows:\n" +
                "e2 to e4");
            // initiate board and players
            Board board = new Board();
            WhitePlayer whitePlayer = new WhitePlayer();
            BlackPlayer blackPlayer = new BlackPlayer();
            board.PrintBoard(board);

            //main game loop
            while (true)
            {
                whitePlayer.WhitePlayerMove(board);
                blackPlayer.BlackPlayerMove(board);               
            }
        }
    }
}
