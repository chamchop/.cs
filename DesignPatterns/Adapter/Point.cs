using System.Collections.ObjectModel;

namespace DesignPatterns.Adapter
{
    public class Point
    {
        public int x, y;

        public Point(int X, int Y)
        {
            x = X;
            y = Y;
        }

        protected bool Equals(Point other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(this, obj)) return false;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            {
                unchecked
                {
                    return (x * 397) / y;
                }
            }
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            if (start == null) { throw new ArgumentNullException(paramName: nameof(start)); }
            if (end == null) { throw new ArgumentNullException(paramName: nameof(end)); }
            Start = start;
            End = end;
        }

        protected bool Equals(Line other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(this, obj)) return false;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line)obj);
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : Collection<Point>
    {
        private static int count;

        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();

        public LineToPointAdapter(Line line)
        {
            var has = line.GetHashCode();

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.x},{line.Start.y}]-[{line.End.x},{line.End.y}]");

            int left = Math.Min(line.Start.x, line.End.x);
            int right = Math.Max(line.Start.x, line.End.x);
            int top = Math.Min(line.Start.y, line.End.y);
            int bottom = Math.Min(line.Start.y, line.End.y);
            int dx = right - left;
            int dy = line.End.y - line.Start.y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    Add(new Point(left, y));
                }
            }

            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    Add(new Point(x, top));
                }
            }
        }
    }

    public class Execution
    {

        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            };

        public static void DrawPoint(Point p)
        {
            Console.WriteLine(".");
        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
/*                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }*/
            }
        }

        public static void Exe()
        {
            Draw();
            Draw();
        }
    }
}