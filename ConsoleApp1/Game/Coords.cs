using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    public class Coords
    {
        int x;
        int y;
        public Coords(int y, int x)
        {
            setY(y);
            setX(x);
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
        public bool setX(int X)
        {
           
            this.x = X;
            return true;
        }
        public int getX()
        {
            return x;
        }
    }
}
