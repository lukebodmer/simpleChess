using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    public class Figure
    {
        private bool AlreadyMoved = false;
        public bool HasMoved
        {
            get
            {
                return AlreadyMoved;
            }
            set
            {
                AlreadyMoved = value;
            }
        }
        public string Color { get; set; }

        public Figure(string Color)
        {
            this.Color = Color;
        }
        public virtual string Symbol { get; set; }

        public Figure()
        {
            Color = " ";
        }

        // this can be used to identify type of piece
        public string Name()
        {
            return GetType().Name;
        }

        public virtual bool Move(Board board, Coord start, Coord end, string type, string moveCase)
        {
            return true;
        } 
    }
}
