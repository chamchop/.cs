using System.Drawing;

namespace DesignPatterns.Singleton
{
    public class AmbientContext
    {

        public sealed class BuildingContext : IDisposable
        {
            public int WallHeight;
            private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

            static BuildingContext()
            {
                stack.Push(new BuildingContext(0));
            }

            public BuildingContext(int wallHeight)
            {
                WallHeight = wallHeight;
                stack.Push(this);
            }

            public static BuildingContext Current => stack.Peek();

            public void Dispose()
            {
                if (stack.Count > 1)
                {
                    stack.Pop();
                }
            }
        }

        public class Building
        {
            public List<Wall> Walls = new List<Wall>();
        }

        public class Wall
        {
            public Point Start, End;
            public int Height;

            public Wall(Point start, Point end)
            {
                Start = start;
                End = end;
                Height = BuildingContext.Current.WallHeight;
            }
        }

        public struct Point
        {
            private int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void Exe()
        {
            var house = new Building();

            using (new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

                using (new BuildingContext(3500))
                {
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
                }

                house.Walls.Add(new Wall(new Point(5000, 5000), new Point(5000, 4000)));
            }

            Console.WriteLine(house);
        }
    }
}
