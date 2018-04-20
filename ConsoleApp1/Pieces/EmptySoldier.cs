using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    class EmptySoldier : SoldierBase
    {
        public EmptySoldier(string type, string color, bool moved, int y, int x) : base(type, color, moved, y, x)
        {

        }


        public override string ToString()
        {
            return getColor() + GetType();
        }

        public override bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return false;
        }
    }
}
