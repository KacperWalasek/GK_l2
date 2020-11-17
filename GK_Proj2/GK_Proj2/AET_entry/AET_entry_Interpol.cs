using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK_Projekt2.AET_entry
{
    class AET_entry_Interpol : AET_entry_base
    {
        public AET_entry_Interpol(int id, bool reverse, Polygon p) : base(id, reverse, p)
        {
            int next = (id + 1) % p.vertexes.Count;
            this.color = reverse ? p.vertexColors[next] : p.vertexColors[id];
            R = color.R;
            G = color.G;
            B = color.B;
            this.stepR = (float)(p.vertexColors[next].R - p.vertexColors[id].R) / (p.vertexes[next].Y - p.vertexes[id].Y);
            this.stepG = (float)(p.vertexColors[next].G - p.vertexColors[id].G) / (p.vertexes[next].Y - p.vertexes[id].Y);
            this.stepB = (float)(p.vertexColors[next].B - p.vertexColors[id].B) / (p.vertexes[next].Y - p.vertexes[id].Y);
        }
        public override void yStep()
        {
            base.yStep();
            R += stepR;
            G += stepG;
            B += stepB;
            color = Color.FromArgb((int)R, (int)G, (int)B);
        }
        public override Color xStep(AET_entry_base to, int x, int y)
        {
            Color c = Color.FromArgb((int)xR, (int)xG, (int)xB);
            xR += xStepR;
            xG += xStepG;
            xB += xStepB;
            setFillPoint(to, new FillPoint(x, y, 0, c, new float[] { 0, 0, 1 }));
            return c;
        }
        public override bool beforeDraw(AET_entry_base to, int y)
        {
            base.beforeDraw(to, y);
            AET_entry_Interpol To = to as AET_entry_Interpol;
            float div = to.x - x;
            if (div == 0)
            {
                return false;
            }
            xStepR = ((float)(To.color.R - color.R) / div);
            xStepG = ((float)(To.color.G - color.G) / div);
            xStepB = ((float)(To.color.B - color.B) / div);
            xR = color.R;
            xG = color.G;
            xB = color.B;
            return true;
        }
        public Color color;
        public float R;
        public float G;
        public float B;
        public float stepR;
        public float stepG;
        public float stepB;
        // state
        public float xR;
        public float xG;
        public float xB;
        public float xStepR;
        public float xStepG;
        public float xStepB;
    }
}
