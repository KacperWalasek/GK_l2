using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GK_Projekt2.AET_entry
{
    class AET_entry_Fill : AET_entry_base
    {
        public AET_entry_Fill(int id, bool reverse, Polygon p) : base(id, reverse, p)
        {
            color = p.fillColor;
        }
        public override Color xStep(AET_entry_base to, int x, int y)
        {
            setFillPoint(to, new FillPoint(x, y,0, color, new float[] { 0, 0, 1 }));
            return DrawEngine.sun.newColor(new Point(x, y), 0, color, new float[] { 0, 0, 1 });
        }
        public Color color; 
    }
}
