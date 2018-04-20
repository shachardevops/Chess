using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class BishopPiece : SoldierBase
    {

        public BishopPiece(string type, string color, bool moved, int y, int x) : base(type, color, moved, y, x)
        {

        }
        public override bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return DiagonalMoves(board, start, end);
        }
        public bool DiagonalMoves(ChessBoard board, Coords start, Coords end)
        {
            if (Math.Abs(start.getX() - end.getX()) == Math.Abs(start.getY() - end.getY()))
            {



                if (start.getY() > end.getY() && start.getX() > end.getX())
                {//y--x--
                    for (int tempStartY = start.getY() - 1, tempStartX = start.getX() - 1; tempStartY > end.getY() && tempStartX > end.getX(); tempStartY--, tempStartX--)
                    {
                        if (board.GetSoldierByPosition(new Coords(tempStartY, tempStartX)).getColor() != " ")
                        {
                            return false;  // If there is one (not empty) movement isn't allowed
                        }
                    }
                }
                else if (start.getY() > end.getY() && start.getX() < end.getX())
                {//y--x++
                    for (int tempStartY = start.getY() - 1, tempStartX = start.getX() + 1; tempStartY > end.getY() && tempStartX < end.getX(); tempStartY--, tempStartX++)
                    {
                        if (board.GetSoldierByPosition(new Coords(tempStartY, tempStartX)).getColor() != " ")
                        {
                            return false;  // If there is one (not empty) movement isn't allowed
                        }
                    }
                }
                else if (start.getY() < end.getY() && start.getX() < end.getX())
                {//y++x++
                    for (int tempStartY = start.getY() + 1, tempStartX = start.getX() + 1; tempStartY > end.getY() && tempStartX < end.getX(); tempStartY++, tempStartX++)
                    {
                        if (board.GetSoldierByPosition(new Coords(tempStartY, tempStartX)).getColor() != " ")
                        {
                            return false;  // If there is one (not empty) movement isn't allowed
                        }
                    }
                }
                else if (start.getY() < end.getY() && start.getX() > end.getX())
                {//y++x--
                    for (int tempStartY = start.getY() + 1, tempStartX = start.getX() - 1; tempStartY > end.getY() && tempStartX < end.getX(); tempStartY++, tempStartX--)
                    {
                        if (board.GetSoldierByPosition(new Coords(tempStartY, tempStartX)).getColor() != " ")
                        {
                            return false;  // If there is one (not empty) movement isn't allowed
                        }
                    }
                }

                return board.GetSoldierByPosition(end).getColor() == " "||canIeat(board, start, end)  ;

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
            return "" + getColor() + GetType();
        }

    }
}
