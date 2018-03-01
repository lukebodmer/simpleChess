using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class Knight : Figure
    {
        public override string Symbol
        {
            get { return "R"; }
            set { }
        }
        public Knight(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            // impliment rules for knights
            if (((Math.Abs(board.ChangeInVertical(start, end)) == 1) && (Math.Abs(board.ChangeInHorizontal(start, end)) == 2))
                || ((Math.Abs(board.ChangeInVertical(start, end)) == 2) && (Math.Abs(board.ChangeInHorizontal(start, end)) == 1)))
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
