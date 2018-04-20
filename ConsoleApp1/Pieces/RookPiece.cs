using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class RookPiece : SoldierBase
    {
        public RookPiece(string type, string color, bool moved, int y, int x) : base(type, color, moved, y, x)
        {

        }

        public override bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return StraightLines(board, start, end);
        }

        public bool StraightLines(ChessBoard board, Coords start, Coords end)
        {
            if (start.getX() == end.getX())
            {
                if (start.getY() < end.getY())
                {
                    for (int i = start.getY() + 1; i < end.getY(); i++)
                    {
                        if (board.GetSoldierByPosition(new Coords(i, start.getX())).getColor() != " ")
                        {
                            return false;  // If there is one (not empty) movement isn't allowed
                        }
                    }
                }
                else
                {
                    for (int i = start.getY() - 1; i > end.getY(); i--)
                    {
                        if (board.GetSoldierByPosition(new Coords(i, start.getX())).getColor() != " ")
                        {
                            return false;
                        }
                    }
                }
                return canIeat(board, start, end) || board.GetSoldierByPosition(end).getColor() == " ";

            }
            else if (start.getY() == end.getY())
            {
                if (start.getX() < end.getX())
                {
                    for (int i = start.getX() + 1; i < end.getX(); i++)
                    {
                        if (board.GetSoldierByPosition(new Coords(start.getY(), i)).getColor() != " ")
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = start.getX() - 1; i > end.getX(); i--)
                    {
                        if (board.GetSoldierByPosition(new Coords(start.getY(), i)).getColor() != " ")
                        {
                            return false;
                        }
                    }
                }
                return canIeat(board, start, end) || board.GetSoldierByPosition(end).getColor() == " ";
            }
            return false;
        }
        public bool canIeat(ChessBoard board, Coords start, Coords end)
        {
            if (board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return getColor() + GetType();
        }
    }
}
