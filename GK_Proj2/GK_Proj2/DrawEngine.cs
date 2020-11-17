using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.AET_entry;
using GK_Projekt2.AET_entry.factories;
namespace GK_Projekt2
{
    static class DrawEngine
    {
        public static Sun sun = new Sun(new Point(100,100), 500, 1, 1, 200, Color.White);
        public static void DrawPixel(Bitmap bitmap, int x, int y, Color color)
        {
            if (x < 0 || y < 0 || x >= bitmap.Width || y >= bitmap.Height)
                return;
            bitmap.SetPixel(x, y, color);

        }
        public static void MidpointLineDrawer(Bitmap bitmap, Point from, Point to, Color color, out Dictionary<Point,Color> pointSet)
        {
            pointSet = new Dictionary<Point, Color>();
            bool swapXY = false;
            int swapOX = 1;
            if (Math.Abs(to.X - from.X) < Math.Abs(to.Y - from.Y))
            {
                swapXY = true;
                from = new Point(from.Y, from.X);
                to = new Point(to.Y, to.X);
            }
            if(from.X>to.X)
            {
                Point tmp = from;
                from = to;
                to = tmp;
            }
            if (from.Y > to.Y)
                swapOX = -1;
            int dx = to.X - from.X;
            int dy = to.Y - from.Y;
            int d = 2 * swapOX * dy - dx;
            int incrE = 2 * swapOX * dy;
            int incrNE = 2 * (swapOX * dy - dx);
            int x = from.X;
            int y = from.Y;
            pointSet.Add(new Point(swapXY ? y : x, swapXY ? x : y), color);
            DrawPixel(bitmap, swapXY? y : x, swapXY? x : y, color);
            while (x < to.X)
            {
                if (d < 0)
                {
                    d += incrE;
                    x++;
                }
                else
                {
                    d += incrNE;
                    x++;
                    y+=swapOX;
                }
                pointSet.Add(new Point(swapXY ? y : x, swapXY ? x : y), color);
                DrawPixel(bitmap, swapXY ? y : x, swapXY ? x : y, color);
            }
        }
        public static void FillPolygon(Bitmap bitmap, Polygon p, AET_factory factory, Point relativePosition)
        {
            List<AET_entry_base> AET = new List<AET_entry_base>();
            int ymin = p.vertexes[p.sortedVertexes[0]].Y;
            int ymax = p.vertexes[p.sortedVertexes[p.vertexes.Count - 1]].Y;
            p.fillPoints = new FillPoint[ymax-ymin][];
            int nextVert = 0;
            for (int y = ymin + 1; y < ymax; y++)
            {
                while (nextVert < p.vertexes.Count && p.vertexes[p.sortedVertexes[nextVert]].Y == y - 1)
                {
                    int ind = p.sortedVertexes[nextVert];
                    int last = ind == 0 ? p.vertexes.Count - 1 : ind - 1;
                    int next = (ind + 1) % p.vertexes.Count;

                    if (p.vertexes[next].Y >= y)
                        AET.Add(factory.getEntry(ind, false, p));
                    else AET.RemoveAll((AET_entry_base item) => item.id == ind);
                    if (p.vertexes[last].Y >= y)
                        AET.Add(factory.getEntry(last, true, p));
                    else AET.RemoveAll((AET_entry_base item) => item.id == last);
                    nextVert++;
                }

                AET.Sort((AET_entry_base l1, AET_entry_base l2) =>
                {
                    return (int)(l1.x - l2.x);
                });
                for (int i = 0, j = 1; i < AET.Count && j < AET.Count; i += 2, j += 2)
                {
                    AET[i].DrawLine(bitmap, AET[j], y, relativePosition);
                    AET[i].yStep();
                    AET[j].yStep();
                }
            }
        }
    }
}
