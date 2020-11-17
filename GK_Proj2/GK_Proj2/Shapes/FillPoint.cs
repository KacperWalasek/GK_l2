using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK_Projekt2.Shapes
{
    class FillPoint
    {
        public FillPoint(int x, int y,int h, Color color, float[] normalVector)
        {
            this.x = x;
            this.y = y;
            this.h = h;
            this.normalVector = normalVector;
            baseColor = color;
        }
        public int x;
        public int y;
        public int h;
        public Color baseColor;
        public float[] normalVector;
    }
}
