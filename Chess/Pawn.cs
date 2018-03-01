using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    public class Pawn : Figure
    {
        public override string Symbol
        {
            get { return "P"; }
            set { }
        }
        public Pawn(string color)
        {
            this.Color = color;
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            // find direction of movement. Black direction = -1, White direction = 1
            int direction = board.FindFigureDirection(start);

            // first rule for pawns - Moving one unit and attacking 
            if (((board.ChangeInVertical(start, end)) == direction)
                && Math.Abs(board.ChangeInHorizontal(start, end)) == 1
                && moveCase == "Attack")
            {
                return true;
            }
            else if (moveCase == "Empty"                              // pawns can only move into empty spaces 
                && ((board.ChangeInVertical(start, end)) == direction)         // if it is directly ahead of them
                && ((board.ChangeInHorizontal(start, end)) == 0))
            {
                return true;
            }
            else if ((board.GetFigure(start).HasMoved == false)              // they can move two spaces if it is their first move
                && (board.ChangeInVertical(start, end) == 2 * direction)
                && ((board.ChangeInHorizontal(start, end)) == 0)
                && (moveCase == "Empty")
                && (board.IsPathClear(board, start, end, "Rook")))
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
