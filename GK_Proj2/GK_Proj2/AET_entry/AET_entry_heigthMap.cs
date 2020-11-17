using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GK_Projekt2.AET_entry
{
    class AET_entry_heigthMap : AET_entry_base
    {
        public AET_entry_heigthMap(int id, bool reverse, Polygon p, int[,] texture) : base(id, reverse, p)
        {
            corner = p.corner;
            this.texture = texture;
            this.color = p.fillColor;
        }
        public override Color xStep(AET_entry_base to, int x, int y)
        {
            int xIndex = (x - corner.X) % texture.GetLength(0);
            int yIndex = (y - corner.Y) % texture.GetLength(1);
            float[] versor = Sun.getVersor(new float[] {
                (texture[xIndex==texture.GetLength(0)-1? 0 : xIndex+1,yIndex] - texture[xIndex, yIndex]),
                (texture[xIndex,yIndex==texture.GetLength(1)-1? 0 : yIndex+1] - texture[xIndex, yIndex]),
                1
            });
            setFillPoint(to, new FillPoint(x, y, texture[xIndex,yIndex], color, versor));
            return color;//DrawEngine.sun.newColor(new Point(x, y), texture[xIndex, yIndex], color, versor);
        }
        Point corner;
        int[,] texture;
        Color color;
    }
}
