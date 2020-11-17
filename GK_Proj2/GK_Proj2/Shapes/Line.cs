using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Projekt2.Shapes
{
    class Line : IShape
    {
        //IShape
        public Dictionary<Point, Color> Points;
        public bool Active { get; set; }
        private bool renderedOnStable;
        private Point lastRelativePosition;
        public void Render(Bitmap bitmap, Point relativePosition)
        {
            if (!Active && renderedOnStable && lastRelativePosition == relativePosition)
                foreach (var point in Points)
                    DrawEngine.DrawPixel(bitmap, point.Key.X, point.Key.Y, point.Value);
            else
            {
                DrawEngine.MidpointLineDrawer(bitmap, new Point(Position.X+relativePosition.X,Position.Y+relativePosition.Y),
                    new Point(End.X+relativePosition.X,End.Y+relativePosition.Y), Color.Gray, out Points);
                if (!Active)
                {
                    renderedOnStable = true;
                    lastRelativePosition = relativePosition;
                }
            }
        }

        public bool Contains(Point point)
        {
            if ((Position.X - point.X) * (End.X - point.X) > 0) return false;
            return Math.Abs((double)(point.X - Position.X) / (End.X - Position.X) * (End.Y - Position.Y) - (point.Y - Position.Y)) < 4 ||
                Math.Abs((double)(point.Y - Position.Y) / (End.Y - Position.Y) * (End.X - Position.X) - (point.X - Position.X)) < 4;
        }

        //Own
        public Point Position;
        public Point End;
        public int xFromY(int y)
        {
            float dx = End.X - Position.X;
            float dy = End.Y - Position.Y;
            return End.X + (int)Math.Round(dx / dy * (End.Y - y));

        }
        public Line(Point position) 
        {
            Active = true;
            Position = position;
            End = position;
            lastRelativePosition = new Point(0, 0);
        }
    }
}
