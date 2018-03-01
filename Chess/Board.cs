using System;
using System.Collections.Generic;


namespace FourByFourChess
{
    public class Board
    {
        // starting layout for board
        // black is uppercase P
        // white is lowercase p
        // x is empty space
        const string layout = "rkbqwbkr\n" +
                              "pppppppp\n" +
                              "xxxxxxxx\n" +
                              "xxxxxxxx\n" +
                              "xxxxxxxx\n" +
                              "xxxxxxxx\n" +
                              "PPPPPPPP\n" +
                              "RKBQWBKR";
        // feilds                      
        private static int BoardDimension = 8;
        private Figure[,] FiguresArray = new Figure[BoardDimension, BoardDimension];
        private static Empty DeadPieceEmpty = new Empty();
        private List<Figure> FallenWhites = new List<Figure>();
        private List<Figure> FallenBlacks = new List<Figure>();

        // Constructor
        public Board()
        {
            //create a Figure Array that contains all pieces and empty spaces on board
             int c = 0;
             for(int y = 0; y < BoardDimension; y++)
             {
                for (int x = 0; x < BoardDimension; x++)
                {
                    if (layout[c] == '\n')
                    {
                        c++;
                    }
                    FiguresArray[x, y] = FigureFromLetter(layout[c]);
                    c++;
                }
             }
            
        }

        // Print Board with white at bottom and coord (0,0) at bottom left
        public void PrintBoard(Board board)
        {
            char SquareColor1 = ' ';
            char SquareColor2 = ' ';
            Coord temp = new Coord();
            Console.WriteLine();
            Console.Write("    ###################################################       ");
            for (int i = 0; ((i < FallenBlacks.Count) && (i < 8)); i++ )
            {
                if (FallenBlacks[i].Color == "black")
                {
                    Console.Write("[{0}] ", FallenBlacks[i].Symbol);
                }
            }
            Console.WriteLine();
                Console.Write("    ###################################################       ");
            for (int i = 8; i < FallenBlacks.Count; i++)
            {
                    Console.Write("[{0}] ", FallenBlacks[i].Symbol);
            }
            Console.WriteLine();
            Console.WriteLine("    ##     |:::::|     |:::::|     |:::::|     |:::::##");     
            for (int i = BoardDimension -1; i > -1; i--)
            {
                if ((i % 2 == 0) && (i <= 6))
                {
                    SquareColor1 = ':';
                    SquareColor2 = ' ';
                    Console.WriteLine("    ##{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}" +
                        "|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}##", SquareColor1, SquareColor2);
                }
                else if ((i % 2 != 0) && (i < 6))
                {
                    SquareColor1 = ' ';
                    SquareColor2 = ':';
                    Console.WriteLine("    ##{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}" +
                        "|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}##", SquareColor1, SquareColor2);
                }

                for (int j = 0; j < BoardDimension; j++)
                {
                    temp.x = j;
                    temp.y = i;

                    if (GetFigureName(temp) == "Pawn")
                        PrintSquare(temp, 'P', i, j);
                    else if (GetFigureName(temp) == "Knight")
                        PrintSquare(temp, 'N', i, j);
                    else if (GetFigureName(temp) == "Rook")
                        PrintSquare(temp, 'R', i, j);
                    else if (GetFigureName(temp) == "Bishop")
                        PrintSquare(temp, 'B', i, j);
                    else if (GetFigureName(temp) == "Queen")
                        PrintSquare(temp, 'Q', i, j);
                    else if (GetFigureName(temp) == "King")
                        PrintSquare(temp, 'K', i, j);
                    else
                    {
                        if (GetFigureName(temp) == "Empty" && IsSquareColored(i, j))
                            PrintSquare(temp, ':', i, j);
                        else
                            PrintSquare(temp, ' ', i, j);
                    }

                    if (j == BoardDimension - 1)
                        Console.WriteLine("##  |{0}", i + 1);                   
                }
                if (i % 2 == 0)
                {
                    SquareColor1 = ':';
                    SquareColor2 = ' ';
                    Console.WriteLine("    ##{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}" +
                        "|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}##", SquareColor1, SquareColor2);
                }
                else if (i % 2 != 0)
                {
                    SquareColor1 = ' ';
                    SquareColor2 = ':';
                    Console.WriteLine("    ##{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}" +
                        "|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}|{0}{0}{0}{0}{0}|{1}{1}{1}{1}{1}##", SquareColor1, SquareColor2);
                }
            }

            Console.Write("    ###################################################       ");
            for (int i = 0; ((i < FallenWhites.Count) && (i < 8)); i++)
            {
                    Console.Write("{0} ", FallenWhites[i].Symbol);
            }
            Console.WriteLine();
            Console.Write("    ###################################################       ");
            for (int i = 8; i < FallenWhites.Count; i++)
            {
                    Console.Write("{0} ", FallenWhites[i].Symbol);
            }
            Console.WriteLine();
            Console.WriteLine("     |  A  |  B  |  C  |  D  |  E  |  F  |  G  |  H  |");
        }
        public void PrintSquare(Coord temp, char c, int i, int j)
        {
            string border = " ";
            if (j == 0)
            {
                Console.Write("    ");
                border = "##";
            }
            else
            {
                border = "|";
            }
            if ((IsFigureWhite(temp) || (GetFigureName(temp) =="Empty")) && IsSquareColored(i, j))
            {
                Console.Write("{0}::{1}::", border,c);
            }
            else if ((IsFigureWhite(temp) || (GetFigureName(temp) == "Empty")) && !IsSquareColored(i, j))
            {
                Console.Write("{0}  {1}  ", border, c);
            }
            else if (IsFigureBlack(temp) && IsSquareColored(i, j))
            {
                Console.Write("{0}:[{1}]:", border, c);
            }
            else if (IsFigureBlack(temp) && !IsSquareColored(i, j))
            {
                Console.Write("{0} [{1}] ", border, c);
            }
        }
        public bool IsSquareColored(int i, int j)
        {
            if ((j == i) || (i == (j + 2)) || (i == (j + 4)) || (i == (j + 6))
                || (i == (j - 2)) || (i == (j - 4)) || (i == (j - 6)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Figure FigureFromLetter (char c)
        {
            Figure result = new Figure();
            string color = "black";

            if (Char.IsLower(c))
            {
                c = Char.ToUpper(c);
                color = "white";
            }
                switch (c)
                {
                    case 'P':
                        result = new Pawn(color);
                        break;
                    case 'K':
                    result = new Knight(color);
                        break;
                    case 'R':
                    result = new Rook(color);
                        break;
                    case 'B':
                    result = new Bishop(color);
                        break;
                    case 'Q':
                    result = new Queen(color);
                        break;
                    case 'W':
                    result = new King(color);
                        break;
                default:
                        result = new Empty();
                        break;
                } 
            return result;
        }

        public void Move(Board board, Coord start, Coord end)
        {
            string moveCase = " ";
            //decide what type of piece you are moving and execute accordingly 
            if (IsAttackingOtherTeam(start, end))
            {
                moveCase = "Attack";
            }
            else if (GetFigureName(end) == "Empty")
            {
                moveCase = "Empty";
            }
            else
            {
                throw new Exception(String.Format("Error: You must attack or move into an empty space\n"));
            }

            if (FiguresArray[start.x, start.y].Move(board, start, end, GetFigureName(start), moveCase)
                && moveCase == "Empty")
            {
                MoveIntoEmptySpace(start, end);
            }
            else if (FiguresArray[start.x, start.y].Move(board, start, end, GetFigureName(start), moveCase)
                && moveCase == "Attack")
            {
                KillOtherFigure(start, end);
            }
            else
            {
                throw new Exception(String.Format("Error: this move is not allowed \n"));
            }
            Console.WriteLine();
            PrintBoard(board);
        }


        // Returns true of false if king of specified color is under attack 
        public bool IsCheck(Board board, string AttackerColor)
        {
            Coord attacker = new Coord();
            Coord KingFinder = new Coord();
            Coord KingPosition = new Coord();
            string KingColor = " ";
            bool Check = false;

            //find king color and attacker color
            if (AttackerColor == "white")
                KingColor = "black";
            else if (AttackerColor == "black")
                KingColor = "white";
            
            // find where king is
            for (int i = 0; i < BoardDimension; i++)
            {
                for (int j = 0; j < BoardDimension; j++)
                {
                    KingFinder.x = i;
                    KingFinder.y = j;

                    if (board.GetFigureName(KingFinder) == "King"
                        && board.GetFigureColor(KingFinder) == KingColor)
                    {
                        KingPosition = KingFinder;
                    }
                }
            }

            // see if anything can attack the king
            for (int i = 0; i < BoardDimension; i++)
            {
                for (int j = 0; j < BoardDimension; j++)
                {
                    attacker.x = i;
                    attacker.y = j;
                    // test peices of opposite color (not empty figures)
                    if ((GetFigureColor(attacker) == AttackerColor)
                        && (GetFigureName(attacker) != "Empty")
                        && FiguresArray[attacker.x, attacker.y].Move(board, attacker, KingPosition, GetFigureName(attacker), "Attack"))
                    {
                        Check = true;
                        break;
                    }
                    else
                    {
                        Check = false;
                    }
                }
                if(Check)
                {
                    break;
                }
            }
            return Check;                       
        }

        public bool IsPathClear(Board board, Coord start, Coord end, string type)
        {
            Coord NormalizedVector = FindNormalizedMotionVector(start, end);
            bool PathClear = false;

            if (NumberOfSquaresMoved(start, end, type) == 1
                && ((GetFigureName(end) == "Empty")|| (GetFigureColor(end) != GetFigureColor(start))))
            {
                PathClear = true;
            }
            else
            {
                for (int i = 1; i < NumberOfSquaresMoved(start, end, type); i++)
                {
                    if (GetFigureName(new Coord(start.x + NormalizedVector.x * i, start.y + NormalizedVector.y * i)) == "Empty")
                    {
                        ++i;
                        PathClear = true;
                    }
                    else
                    {
                        PathClear = false;
                    }
                }
            }            
            return PathClear;
        }
        
        public Coord FindNormalizedMotionVector(Coord start, Coord end)
        {
   
            Coord NormalizedVector = new Coord();

            if (ChangeInVertical(start, end) == 0)
            {
                NormalizedVector.y = 0;
                NormalizedVector.x = ChangeInHorizontal(start, end) / Math.Abs(ChangeInHorizontal(start, end)); ;
            }
            else if (ChangeInHorizontal(start, end) == 0)
            {
                NormalizedVector.y = ChangeInVertical(start, end) / Math.Abs(ChangeInVertical(start, end));
                NormalizedVector.x = 0;
            }
            else
            {
                NormalizedVector.x = ChangeInHorizontal(start, end) / Math.Abs(ChangeInHorizontal(start, end));
                NormalizedVector.y = ChangeInVertical(start, end) / Math.Abs(ChangeInVertical(start, end));
            }
            return NormalizedVector;
        }
        
        public int FindFigureDirection(Coord start)
        {
            // find direction of movement
            if (IsFigureWhite(start))
                return 1;
            else
                return -1;
        }

        public int ChangeInHorizontal(Coord start, Coord end)
        {
            return end.x - start.x;
        }
        public int ChangeInVertical(Coord start, Coord end)
        {
            return end.y - start.y;
        }

        public bool IsAttackingOtherTeam(Coord start, Coord end)
        {
            if ((IsFigureWhite(start) && IsFigureBlack(end)) ||             // the pawn attacking the opposite team
                (IsFigureBlack(start) && IsFigureWhite(end)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void KillOtherFigure(Coord start, Coord end)
        {
            if (IsFigureWhite(end))
            {
                FallenWhites.Add(FiguresArray[end.x, end.y]);
            }  
            else
            {
                FallenBlacks.Add(FiguresArray[end.x, end.y]);
            }
            FiguresArray[end.x, end.y] = FiguresArray[start.x, start.y];
            FiguresArray[start.x, start.y] = DeadPieceEmpty;
            FiguresArray[end.x, end.y].HasMoved = true;

        }

        public void MoveIntoEmptySpace(Coord start, Coord end)
        {
            Figure Temp = FiguresArray[end.x, end.y];
            FiguresArray[end.x, end.y] = FiguresArray[start.x, start.y];
            FiguresArray[start.x, start.y] = Temp;
            FiguresArray[end.x, end.y].HasMoved = true;

        }

        public int NumberOfSquaresMoved(Coord start, Coord end, string type)
        {
            int Number = new int();

            if (type == "Bishop")
            {
                Number = Math.Abs(ChangeInHorizontal(start, end));
            }
            else if (type == "Rook")
            {
                Number = (Math.Abs(ChangeInHorizontal(start, end)) > Math.Abs(ChangeInVertical(start, end))) ? Math.Abs(ChangeInHorizontal(start, end))
                    : Math.Abs(ChangeInVertical(start, end));
            }
            else
            {
                throw new Exception(String.Format("Error: I don't know how you managed this error"));
            }
            return Number;
        }

        public bool IsFigureWhite(Coord coord)
        {

            if (GetFigureColor(coord) == "white")
                return true;
            else
                return false;
        }

        public bool IsFigureBlack(Coord coord)
        {

            if (GetFigureColor(coord) == "black")
                return true;
            else
                return false;
        }

        public string GetFigureName(Coord c)
        {
            return GetFigure(c).Name();
        }

        public string GetFigureColor(Coord c)
        {
            return GetFigure(c).Color;
        }

        public Figure GetFigure(Coord c)
        {
            return this.FiguresArray[c.x, c.y];
        }
        public bool CheckInPlay()
        {
            bool InPlay = true;
            return InPlay;
        }

    }
}
