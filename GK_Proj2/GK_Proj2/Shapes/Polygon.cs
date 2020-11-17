using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GK_Projekt2.AET_entry.factories;
namespace GK_Projekt2.Shapes
{
    class Polygon : IShape
    {
        //IShape
        public Point Position { get; private set; }

        private bool active = true;
        public bool Active {
            get => active;
            set
            {
                active = value;
                if (value == false)
                    renderInactive = false;
            }
        } 
        private bool renderInactive = false;

        public bool Contains(Point point)
        {
            foreach(Line line in lines)
                if(line.Contains(new Point(point.X - relativePosition.X, point.Y - relativePosition.Y)))
                    return true;
            return Array.Exists(fillPoints, line => line!=null && Array.Exists(line, p => p.x + relativePosition.X == point.X && p.y + relativePosition.Y == point.Y ));
        }

        public void Render(Bitmap bitmap)
        {
            if(Active)
                foreach (Line line in lines)
                    line.Render(bitmap, relativePosition);
            if (!Active)
            {
                if (!renderInactive)
                {
                    renderInactive = true;
                    DrawEngine.FillPolygon(bitmap, this, fillFactory, relativePosition);
                }
                foreach (FillPoint[] line in fillPoints)
                    if (line != null)
                        foreach (FillPoint point in line)
                            if(point!=null)
                                DrawEngine.DrawPixel(bitmap, relativePosition.X + point.x, relativePosition.Y + point.y,
                                    DrawEngine.sun.newColor(new Point(relativePosition.X + point.x, relativePosition.Y + point.y), point.h, point.baseColor, point.normalVector));

            }
        }
        //Own
        const int vertexSize = 5;
        public List<Point> vertexes;
        public List<Color> vertexColors;
        public List<int> sortedVertexes;
        public int minX = int.MaxValue;
        public int maxX = -1;
        public (int x, int y, int v) velocity;
        public List<Line> lines;
        private Point relativePosition;
        private int moved;
        Point catchPoint;
        private List<Line> activeLines;
        public Color fillColor;
        public Point corner;
        public AET_factory fillFactory;
        public FillPoint[][] fillPoints;
        private Random random;
        public Polygon(Point position, Color vertexColor, Color fillColor, AET_factory fillFactory)
        {
            random = new Random();
            Position = position;
            corner = position;
            relativePosition = new Point(0, 0);
            lines = new List<Line>();
            vertexes = new List<Point>();
            vertexColors = new List<Color>();
            sortedVertexes = new List<int>();
            activeLines = new List<Line>();
            this.fillColor = fillColor;
            this.fillFactory = fillFactory;
            AddLine(position, vertexColor);
        }
        public void MouseMove(Point point)
        {
            Point relative = new Point(point.X - relativePosition.X, point.Y - relativePosition.Y);
            switch(activeLines.Count)
            {
                case 1:
                    activeLines[0].End = relative;
                    break;
                case 2:
                    MoveVerticle(moved, relative);
                    break;
                case 3:
                    MoveVerticle(moved, new Point(vertexes[moved].X + (point.X - catchPoint.X),
                                                  vertexes[moved].Y + (point.Y - catchPoint.Y)));
                    int index = (moved + 1) % lines.Count;
                    MoveVerticle(index, new Point(vertexes[index].X + (point.X - catchPoint.X),
                                                  vertexes[index].Y + (point.Y - catchPoint.Y)));
                    catchPoint = point;
                    break;
                case 0:
                    relativePosition.X += point.X - catchPoint.X;
                    relativePosition.Y += point.Y - catchPoint.Y;
                    catchPoint = point;
                    break;
            }
        }
        public void Click(Point point, Mode mode, Color vertexColor)
        {
            if (Active)
            {
                if (activeLines.Count == 1)
                {
                    if (lines.Count > 2 && VertexContains(Position, point))
                    {
                        activeLines[0].End = Position;
                        activeLines[0].Active = false;
                        activeLines.RemoveAt(0);
                        Active = false;
                        return;
                    }
                    activeLines[0].Active = false;
                    activeLines.RemoveAt(0);
                    AddLine(point, vertexColor);
                }
                else 
                {
                    if(activeLines.Count == 0)
                    {
                        Active = false;
                        return;
                    }
                    updateVertexIndex(moved);

                    if (activeLines.Count == 3)
                    {
                        updateVertexIndex((moved + 1) % vertexes.Count);
                        updateVertexIndex(moved);
                    }
                    recalculateCorner();
                    foreach (Line line in activeLines)
                        line.Active = false;
                    Active = false;
                    activeLines.Clear();
                }
            }
            else
            {
                switch(mode)
                {
                    case Mode.Edit:
                        EditClick(point);
                        break;
                    case Mode.Delete:
                        DeleteClick(point);
                        break;
                    case Mode.Add:
                        AddClick(point, vertexColor);
                        break;
                }
            }
        }
        public void Move(int width, int height)
        {
            //Console.WriteLine($"{velocity.x * velocity.x + velocity.y * velocity.y}, {velocity.v* velocity.v}");
            relativePosition.X += velocity.x;
            relativePosition.Y += velocity.y;
            if ((minX + relativePosition.X) < 0)
                bounceR();
            else if ((maxX + relativePosition.X) > width)
                bounceL();
            else if ((vertexes[sortedVertexes[0]].Y + relativePosition.Y) < 0)
                bounceD();
            else if ((vertexes[sortedVertexes[sortedVertexes.Count-1]].Y + relativePosition.Y) >height)
                bounceU();

        }
        private void EditClick(Point point)
        {
            Point relative = new Point(point.X - relativePosition.X, point.Y - relativePosition.Y);
            for (int i = 0; i < vertexes.Count; i++)
                if (VertexContains(vertexes[i], relative))
                {
                    moved = i;
                    ActivateLine(i);
                    ActivateLine(i == 0 ? lines.Count - 1 : (i - 1));
                    Active = true;
                    return;
                }
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].Contains(relative))
                {
                    moved = i;
                    catchPoint = point;
                    ActivateLine(i);
                    ActivateLine(i == 0 ? lines.Count - 1 : (i - 1));
                    ActivateLine((i + 1) % lines.Count);
                    lines[i].Active = true;
                    Active = true;
                    return;
                }
            catchPoint = point;
            Active = true;
        }
        public void ChangeClick(Point point, AET_factory factory, Color fillColor, Color vertexColor)
        {
            Point relative = new Point(point.X - relativePosition.X, point.Y - relativePosition.Y);
            for (int i = 0; i < vertexes.Count; i++)
                if (VertexContains(vertexes[i], relative))
                {
                    vertexColors[i] = vertexColor;
                }
            fillFactory = factory;
            this.fillColor = fillColor;
            renderInactive = false;
        }
        private void DeleteClick(Point point)
        {
            Point relative = new Point(point.X - relativePosition.X, point.Y - relativePosition.Y);
            if (vertexes.Count < 4)
                return;
            for (int i = 0; i < vertexes.Count; i++)
                if (VertexContains(vertexes[i], relative))
                {
                    vertexes.RemoveAt(i);                   
                    vertexColors.RemoveAt(i);
                    recalculateCorner();
                    foreach (Point p in vertexes)
                        updateCorner(p);
                    for (int j = 0; j < sortedVertexes.Count; j++)
                    {
                        if (sortedVertexes[j] == i)
                        {
                            sortedVertexes.RemoveAt(j);
                            if (j == sortedVertexes.Count)
                                break;
                        }
                        if (sortedVertexes[j] > i) sortedVertexes[j]--;
                    }
                    int index = i == 0 ? lines.Count - 1 : i - 1;
                    lines[index] = new Line(lines[index].Position);
                    lines[index].End = lines[i].End;
                    lines[index].Active = false;
                    lines.RemoveAt(i);
                    renderInactive = false;
                    return;
                }
        }
        private void AddClick(Point point, Color vertexColor)
        {
            Point relative = new Point(point.X - relativePosition.X, point.Y - relativePosition.Y);
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].Contains(relative))
                {
                    lines[i].End = point;
                    lines.Insert(i + 1, new Line(point));
                    lines[i + 1].End = lines[(i + 2) % lines.Count].Position;
                    lines[i + 1].Active = false;
                    updateCorner(relative);
                    vertexes.Insert(i + 1, relative);
                    vertexColors.Insert(i + 1, vertexColor);
                    for (int j = 0; j < sortedVertexes.Count; j++)
                        if (sortedVertexes[j] > i) 
                            sortedVertexes[j]++;
                    sortedVertexes.Add(i + 1);
                    moved = i + 1;
                    ActivateLine(i);
                    ActivateLine(i + 1);
                    Active = true;
                    return;
                }
        }
        private bool VertexContains(Point vertex, Point point)
        {
            return Math.Abs(vertex.X - point.X) < vertexSize && Math.Abs(vertex.Y - point.Y) < vertexSize;
        }
        private void MoveVerticle(int i, Point point)
        {
            vertexes[i] = point;
            lines[i].Position = point;
            lines[i == 0 ? lines.Count - 1 : (i - 1)].End = point;
        }
        private void AddLine(Point position, Color vertexColor)
        {
            updateCorner(position);
            vertexes.Add(position);
            vertexColors.Add(vertexColor);
            int i;
            for (i = 0; i < vertexes.Count - 1; i++)
                if (vertexes[sortedVertexes[i]].Y > position.Y)
                    break;
            sortedVertexes.Insert(i,vertexes.Count-1);
            Line line = new Line(position);
            lines.Add(line);
            activeLines.Add(line);
        }
        private void ActivateLine(int i)
        {
            activeLines.Add(lines[i]);
            lines[i].Active = true;
        }
        private void updateVertexIndex(int i)
        {
            int index = 0;
            while (sortedVertexes[index] != i)
                index++;
            int newIndex = index;
            while (newIndex != 0 && vertexes[sortedVertexes[newIndex - 1]].Y > vertexes[sortedVertexes[index]].Y)
                newIndex--;
            while (newIndex != vertexes.Count - 1 && vertexes[sortedVertexes[newIndex + 1]].Y < vertexes[sortedVertexes[index]].Y)
                newIndex++;
            sortedVertexes.RemoveAt(index);
            sortedVertexes.Insert(newIndex, i);
        }
        private void updateCorner(Point v)
        {

            if (v.X < corner.X)
                corner.X = v.X;
            if (v.Y < corner.Y)
                corner.Y = v.Y;
            if (v.X < minX)
                minX = v.X;
            if (v.X > maxX)
                maxX = v.X;
        }
        private void recalculateCorner()
        {
            corner = vertexes[0];
            minX = vertexes[0].X;
            maxX = vertexes[0].X;
            foreach (Point v in vertexes)
                updateCorner(v);
        }
        public void startMoving(int minVelocity, int maxVelocity)
        {
            int v = random.Next(minVelocity, maxVelocity);
            int x = random.Next(-v, v);
            int y = (int)Math.Sqrt(v * v - x * x) * (random.Next(0,1)==0?1:-1);
            velocity = (x, y, v);
        }
        private void bounceR()
        {
            int v = velocity.v;
            int x = random.Next(0, v);
            velocity = (
                x,
                (int)Math.Sqrt(v * v - x * x) * (random.Next(0, 1) == 0 ? 1 : -1),
                v
            );
        }
        private void bounceL()
        {
            int v = velocity.v;
            int x = random.Next(0, v);
            velocity = (
                -x,
                (int)Math.Sqrt(v * v - x * x) *( random.Next(0, 1) == 0 ? 1 : -1),
                v
            );
        }
        private void bounceD()
        {
            int v = velocity.v;
            int x = random.Next(-v, v);
            velocity = (
                x,
                (int)Math.Sqrt(v * v - x * x),
                v
            );
        }
        private void bounceU()
        {
            int v = velocity.v;
            int x = random.Next(-v, v);
            velocity = (
                x,
                -(int)Math.Sqrt(v * v - x * x),
                v
            );
        }
    }
}
