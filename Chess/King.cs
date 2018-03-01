using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    class King : Figure
    {
        public override string Symbol
        {
            get { return "K"; }
            set { }
        }
        public King(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            if ((Math.Abs(board.ChangeInHorizontal(start, end)) == 0 || Math.Abs(board.ChangeInHorizontal(start, end)) == 1) // if change in x is 0 or 1
                && (Math.Abs(board.ChangeInVertical(start, end)) == 1 || Math.Abs(board.ChangeInVertical(start, end)) == 0)  // and change in y is 0 or 1
                && (board.GetFigureName(end) == "Empty" || (board.GetFigureName(end) != board.GetFigureColor(start))))       // and is not attacking own color
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
