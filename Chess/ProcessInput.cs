using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourByFourChess
{
    public class ProcessInput
    {
        private char a;
        private char b;
        private char c;
        private char d;
        private Coord positionStart = new Coord();
        private Coord positionEnd = new Coord();

        // properties
        public Coord Start
        {
            get
            {
                return positionStart;
            }
            set
            {
                positionStart = value;
            }
        }

        public Coord End
        {
            get
            {
                return positionEnd;
            }
            set
            {
                positionEnd = value;
            }
        }
        // Constructor
        public ProcessInput(string move)
        {
            Char delimiter = ' ';
            String[] eachMove = move.Split(delimiter);
            string firstPosition = eachMove[0];
            string secondPosition = eachMove[2];
            
            a = firstPosition[0];
            b = firstPosition[1];
            c = secondPosition[0];
            d = secondPosition[1];

            this.positionStart = FindPosition(a, b);
            this.positionEnd = FindPosition(c, d);


        }

        //gives the meaning of the second part of first user input

        public Coord FindPosition(char a, char b)
        {
            Coord temp = new Coord();

            switch(a)
            {
                case 'a':
                    temp.x = 0;
                    temp.y = CheckB(b);
                    return temp;
                case 'b':
                    temp.x = 1;
                    temp.y = CheckB(b);
                    return temp;
                case 'c':
                    temp.x = 2;
                    temp.y = CheckB(b);
                    return temp;
                case 'd':
                    temp.x = 3;
                    temp.y = CheckB(b);
                    return temp;
                case 'e':
                    temp.x = 4;
                    temp.y = CheckB(b);
                    return temp;
                case 'f':
                    temp.x = 5;
                    temp.y = CheckB(b);
                    return temp;
                case 'g':
                    temp.x = 6;
                    temp.y = CheckB(b);
                    return temp;
                case 'h':
                    temp.x = 7;
                    temp.y = CheckB(b);
                    return temp;
                default:
                    throw new Exception(String.Format("Error: incorrect input first character"));

            }

        }

        public int CheckB(char second)
        {
            int yvalue = 0;
            switch (second)
            {
                case '1':
                    yvalue = 0;
                    return yvalue; 
                case '2':
                    yvalue = 1;
                    return yvalue;
                case '3':
                    yvalue = 2;
                    return yvalue;
                case '4':
                    yvalue = 3;
                    return yvalue;
                case '5':
                    yvalue = 4;
                    return yvalue;
                case '6':
                    yvalue = 5;
                    return yvalue;
                case '7':
                    yvalue = 6;
                    return yvalue;
                case '8':
                    yvalue = 7;
                    return yvalue;
                default:
                    throw new Exception( String.Format("Error: incorrect input second character"));
            }
       
        }


    }
}
