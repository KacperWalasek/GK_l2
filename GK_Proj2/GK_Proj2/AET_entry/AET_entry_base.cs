using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Shapes;
using System.Drawing;

namespace GK_Projekt2.AET_entry
{
    class AET_entry_base
    {
        public AET_entry_base(int id, bool reverse, Polygon p)
        {
            this.id = id;
            int next = (id + 1) % p.vertexes.Count;
            this.x = reverse ? p.vertexes[next].X : p.vertexes[id].X;
            this.step = (float)(p.vertexes[next].X - p.vertexes[id].X) / (p.vertexes[next].Y - p.vertexes[id].Y);
            this.p = p;
        }
        public virtual void yStep()
        {
            x += step;
        }
        public virtual Color xStep(AET_entry_base to, int x, int y)
        {
            setFillPoint(to, new FillPoint(x, y, 0, Color.Black, new float[] { 0, 0, 1 }));
            return Color.Black;
        }
        public void setFillPoint(AET_entry_base to,FillPoint point)
        {
            p.fillPoints[point.y - p.vertexes[p.sortedVertexes[0]].Y ][point.x - (int)x] = point;
        }
        public virtual bool beforeDraw(AET_entry_base to, int y)
        {
            p.fillPoints[y - p.vertexes[p.sortedVertexes[0]].Y] = new FillPoint[Math.Abs((int)to.x-(int)x)];
            return true;
        }
        public virtual void DrawLine(Bitmap bitmap, AET_entry_base to, int y, Point relativePosition)
        {
            if(beforeDraw(to, y))
                for (int k = (int)x; k < (int)to.x; k++)
                {
                    DrawEngine.DrawPixel(bitmap, k + relativePosition.X, y + relativePosition.Y, xStep(to,k,y));
                }
        }
        public int id;
        public float x;
        public float step;
        Polygon p;
    }
}
