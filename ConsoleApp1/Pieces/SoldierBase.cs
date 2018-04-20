using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    public class SoldierBase
    {

        string type;
        int y;
        int x;
        bool moved;
        string color;

        public SoldierBase() { }
        public SoldierBase(string type, string color, bool moved, int y, int x)
        {
            setType(type);
            setColor(color);
            setY(y);
            setX(x);
        }
        public bool setType(string type)
        {
            this.type = type;
            return true;
        }
        public string getType()
        {
            return type;
        }
        public bool setY(int Y)
        {
            this.y = Y;
            return true;
        }
        public int getY()
        {
            return y;
        }
        public bool isMoved(bool moved)
        {
            this.moved = moved;
            return true;
        }
        public bool getMoved()
        {
            return moved;
        }
        public bool setX(int X)
        {
            this.x = X;
            return true;
        }
        public int getX()
        {
            return x;
        }
        public bool setColor(string color)
        {
            this.color = color;
            return true;
        }
        public string getColor()
        {
            return color;
        }
        public virtual bool validMove(ChessBoard board, Coords start, Coords end)
        {
            return false;
        }
        public override string ToString()
        {
            return getColor() + GetType();
        }
    }
}