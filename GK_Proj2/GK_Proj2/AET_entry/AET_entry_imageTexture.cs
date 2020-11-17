using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK_Projekt2.AET_entry
{
    class AET_entry_imageTexture : AET_entry_base
    {
        public AET_entry_imageTexture(int id, bool reverse, Polygon p, Color[,] texture) : base(id, reverse, p)
        {
            corner = p.corner;
            this.texture = texture;
        }
        public override Color xStep(AET_entry_base to, int x, int y)
        {
            Color c = texture[(x - corner.X) % texture.GetLength(0), (y - corner.Y) % texture.GetLength(1)];
            setFillPoint(to, new FillPoint(x, y, 0, c, new float[] { 0, 0, 1 }));
            return c;
        }
        Point corner;
        Color[,] texture;
    }
}
