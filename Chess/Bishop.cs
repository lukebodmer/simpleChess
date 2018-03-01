using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class Bishop : Figure
    {
        public override string Symbol
        {
            get { return "B"; }
            set { }
        }
        public Bishop(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            //rules for Bishop movement - must move diagonal, cannot jump over pieces
            if ((Math.Abs(board.ChangeInHorizontal(start, end)) == Math.Abs(board.ChangeInVertical(start, end)))
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
