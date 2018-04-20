using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class Game
    {
        public void run()
        {

            bool valid = false;
            ChessBoard c = new ChessBoard();
            c.initSoldiers();
            // !c.checkMate(c.FindKing())

            c.PrintBoard();
            while (!valid)
            {
                Console.WriteLine("Please enter start axis Y, start axis X, end axis Y, end axis X");
                Console.WriteLine("{0}", (c.WhiteTurn() ? "White its your turn:" : "Black its your turn:"));
                string input = Console.ReadLine().Trim(' ');
                if (input.Length == 4)
                {
                    Coords start = new Coords(c.ConvertY(input[0]), c.ConvertX(input[1]));
                    Coords end = new Coords(c.ConvertY(input[2]), c.ConvertX(input[3]));
                    bool validTurn = false;
                    if ((c.WhiteTurn() && c.GetSoldierByPosition(start).getColor() == "W"))
                    {
                        validTurn = true;

                    }
                    if (!(c.WhiteTurn()) && c.GetSoldierByPosition(start).getColor() == "B")
                    {
                        validTurn = true;
                    }

                    if (c.ValidInput(start, end) && validTurn && c.PossibleToCancelCheck(start, end))
                    {

                        if (c.validCastling(start, end) && c.GetSoldierByPosition(start).validMove(c, start, end))

                        {
                            c.doCastlingMove(start, end);
                            c.nextTurn();
                        }
                        else if (c.GetSoldierByPosition(start).validMove(c, start, end))
                        {
                            if (c.GetSoldierByPosition(start).getType() == "P" ||
                               (c.GetSoldierByPosition(start).getColor() != c.GetSoldierByPosition(end).getColor() && c.GetSoldierByPosition(end).getColor() != " ")
                               || c.inCheck(c.FindKing()))

                            {
                                c.setDrawCounter(0);
                            }

                            if (c.validPawnPromotion(start, end))
                            {
                                c.doPromotion(start, end);
                                c.nextTurn();
                            }
                            else if (c.validEnPassant(start,end))
                            {
                                c.doEnPassant(start, end);
                                c.nextTurn();
                            }
                            else
                            {
                                c.basicMove(start, end);
                                c.nextTurn();
                            }
                        }
                    }

                }
                if (c.isDraw(c.FindKing()))
                {
                    Console.WriteLine("Draw");
                    valid = true;
                    break;
                }
                if (c.checkMate(c.FindKing()))
                {
                    Console.WriteLine((!(c.WhiteTurn()) ? "White won" : "Black won"));
                    valid = true;
                }
            }
        }
    }
}

