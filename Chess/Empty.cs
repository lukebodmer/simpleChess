using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    public class Empty : Figure
    {
        public Empty()
        {
        }
        public override bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            return false;
        }
    }
}
