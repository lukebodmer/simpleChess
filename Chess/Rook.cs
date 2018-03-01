using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class Rook : Figure
    {
        public override string Symbol
        {
            get { return "R"; }
            set { }
        }
        public Rook(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            //rules for Rook movement - must move horizontal or vertical, cannot jump over pieces

            if ((Math.Abs(board.ChangeInHorizontal(start, end)) == 0) && (Math.Abs(board.ChangeInVertical(start, end)) != 0)
                || (Math.Abs(board.ChangeInHorizontal(start, end)) != 0) && (Math.Abs(board.ChangeInVertical(start, end)) == 0)
                && board.IsPathClear(board, start, end, type))
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
