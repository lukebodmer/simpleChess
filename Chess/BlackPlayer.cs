using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class BlackPlayer
    {
        private string PlayerColor = "black";
        public BlackPlayer()
        {
        }

        public void BlackPlayerMove(Board board)
        {
            bool Success = true;
            while (Success)
            {
                try
                {
                    Console.Write("\nBlack player, type your move: ");
                    string action = Console.ReadLine();
                    var playerMove = new ProcessInput(action);
                    if (board.IsFigureWhite(playerMove.Start))
                        throw new Exception(String.Format("Error: You must move a black piece\n"));
                    board.Move(board, playerMove.Start, playerMove.End);
                    if (board.IsCheck(board, PlayerColor))
                    {
                        Console.WriteLine("Player White: you are in check.");
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
