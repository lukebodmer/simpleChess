using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class Queen : Figure
    {
        public override string Symbol
        {
            get { return "Q"; }
            set { }
        }
        public Queen(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end,string type, string moveCase)
        {
            if ((Math.Abs(board.ChangeInHorizontal(start, end)) == Math.Abs(board.ChangeInVertical(start, end)))
                && board.ChangeInHorizontal(start, end) != 0
                && board.IsPathClear(board, start, end, "Bishop"))
            {
                return true;
            }
            else if ((board.ChangeInHorizontal(start, end) == 0 || board.ChangeInVertical(start, end) == 0)
                && (board.ChangeInVertical(start, end) != board.ChangeInHorizontal(start, end))
                && board.IsPathClear(board, start, end, "Rook"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
