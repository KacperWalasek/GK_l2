using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK_Projekt2
{
    class Sun
    {
        public Sun(Point position, int h, float ks, float kd, int m, Color color)
        {
            Position = position;
            this.color = color;
            height = h;
            this.ks = ks;
            this.kd = kd;
            this.m = m;
        }
        public Point Position;
        public float kd;
        public float ks;
        public int height;
        public Color color;
        public int m;
        public bool moving = false;
        public void Render(Bitmap bitmap)
        {
            if (!moving)
            {
                Graphics.FromImage(bitmap).FillEllipse(new SolidBrush(color), Position.X - 2, Position.Y - 2, 4, 4);
                Graphics.FromImage(bitmap).DrawEllipse(new Pen(Color.Black, 1), Position.X - 2, Position.Y - 2, 4, 4);
            }
        }
        public bool Clicked(Point point)
        {
            int dx = point.X - Position.X;
            int dy = point.Y - Position.Y;
            if (dx * dx + dy * dy < 25)
            {
                moving = !moving;
                return true;
            }
            return false;
        }
        public void MouseMove(Point point)
        {
            Position = point;
        }
        public Color newColor(Point p, int h, Color color, float[] normalVector)
        {
            float[] sunVersor = getVersor(p, h, Position, height);
            float cos1 = Sun.cos(normalVector, sunVersor);
            float cos2 = Sun.cos(new[] {0f,0f,1f},R(normalVector, sunVersor));
            return Color.FromArgb(colorPart(color.R, this.color.R, cos1, cos2), colorPart(color.G, this.color.G, cos1, cos2), colorPart(color.B, this.color.B, cos1, cos2));
        }
        private static float[] R(float[] N, float[] L)
        {
            float s = 2 * (N[0] * L[0] + N[1] * L[1] + N[2] * L[2]);
            float[] R = new float[] {
                s*N[0]-L[0],
                s*N[1]-L[1],
                s*N[2]-L[2]
            };
            return R;
        }
        public static float cos(float[] v1, float[] v2)
        {
            float ret = v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
            return ret < 0 ? 0 : ret;
        }
        public int colorPart(float basePart, float sunPart, float cos1, float cos2)
        {
            return ((int)(kd * basePart * sunPart * cos1/255)+(int)(ks*basePart*sunPart*Math.Pow(cos2,m)/255))/2;
        }
        public static float[] getVersor(Point a, int hA, Point b, int hB)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            int dz = hB - hA;
            float len = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
            return new float[] { dx / len, dy / len, dz / len };
        }
        public static float[] getVersor(float[] vector)
        {
            float len = (float)Math.Sqrt(vector[0]*vector[0] + vector[1]*vector[1] + vector[2]*vector[2]);
            return new float[] { vector[0] / len, vector[1] / len, vector[2] / len };
        }
    }
}
