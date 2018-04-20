using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class KnightPiece : SoldierBase
    {
        public KnightPiece(string type, string color, bool moved, int y, int x) : base(type, color, moved, y, x)
        {

        }

        public override bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return rMoves(board, start, end);
        }
        public bool rMoves(ChessBoard board, Coords start, Coords end)
        {

            if (start.getX() + 2 == end.getX() && start.getY() + 1 == end.getY() &&//x+2//y+1
                board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() + 2 == end.getX() && start.getY() - 1 == end.getY() &&//x+2//y-1
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() - 2 == end.getX() && start.getY() + 1 == end.getY() &&//x-2//y+1
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() - 2 == end.getX() && start.getY() - 1 == end.getY() &&//x-2//y-1
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() - 1 == end.getX() && start.getY() - 2 == end.getY() &&//x-1//y-2
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() + 1 == end.getX() && start.getY() - 2 == end.getY() &&//x+1//y-2
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() - 1 == end.getX() && start.getY() + 2 == end.getY() &&//x-1//y+2
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
            }
            if (start.getX() + 1 == end.getX() && start.getY() + 2 == end.getY() &&//x+1//y+2
             board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor())
            {
                return board.GetSoldierByPosition(end).getColor() == " " || canIeat(board, start, end);
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
