using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class WhitePlayer
    {
        private string PlayerColor = "white";
        public WhitePlayer()
        {
        }

        public void WhitePlayerMove(Board board)
        {
            bool Success = true;
            while(Success)
            {
                try
                {
                    Console.Write("\nWhite player, type your move: ");
                    string action = Console.ReadLine();
                    var playerMove = new ProcessInput(action);
                    if (board.IsFigureBlack(playerMove.Start))
                    {
                        throw new Exception(String.Format("Error: You must move a white piece\n"));
                    }
                    board.Move(board, playerMove.Start, playerMove.End);
                    if (board.IsCheck(board, PlayerColor))
                    {
                        Console.WriteLine("Player Black: you are in check.");
                    }
                    Success = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    board.PrintBoard(board);
                }
            }
        }
    }
}
