using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class PawnPiece : SoldierBase
    {
        bool firstMoveTwoSteps;

        public PawnPiece(string type, string color, bool moved, bool twoStepsMoved, int y, int x) : base(type, color, moved, y, x)
        {

        }

        public override bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return PawnMove(board, start, end);
        }
        public bool isMovedTwoSteps(bool twoStepsMoved)
        {
            this.firstMoveTwoSteps = twoStepsMoved;
            return true;
        }
        public bool getMovedTwoSteps()
        {
            return firstMoveTwoSteps;
        }
        public bool PawnMove(ChessBoard board, Coords start, Coords end)
        {
            int direction;
            if (board.WhiteTurn())
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            
            if (!this.getMoved() &&//first move 2 steps 
                 start.getX() == end.getX() &&
                 start.getY() + (2 * direction) == end.getY() &&
                 board.GetSoldierByPosition(new Coords(start.getY() + (2 * direction), end.getX())).getType() == " ")
            {
                firstMoveTwoSteps = true;
                return true;
            }
            if (start.getX() == end.getX() &&//move 1 step
                start.getY() + direction == end.getY() &&
                board.GetSoldierByPosition(new Coords(start.getY() + direction, end.getX())).getType() == " ")
                return true;
            if ((start.getX() + 1 == end.getX() || start.getX() - 1 == end.getX()) &&//eating
                start.getY() + direction == end.getY() &&
                board.GetSoldierByPosition(start).getColor() != board.GetSoldierByPosition(end).getColor() &&
                board.GetSoldierByPosition(end).getColor() != " ")
                return canIeat(board, start, end);
            if (board.validEnPassant(start, end))//en passant
                return true;
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
