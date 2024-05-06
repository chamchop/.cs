using static SOLID.SOLID.LSP;

namespace SOLID.SOLID
{
    public class LSP
    {
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public Rectangle()
            {

            }

            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
            }
        }

        public class Square : Rectangle
        {
            public override int Width { set { base.Width = base.Height = value; } }
            public override int Height { set { base.Width = base.Height = value; } }
        }

        public class Print
        {
            static public int Area(Rectangle r) => r.Width * r.Height;

            public static void Exe()
            {
                var r = new Rectangle(2, 3);
                Console.WriteLine(Area(r));

                Rectangle s = new Square();
                s.Width = 4;
                Console.WriteLine(Area(s));
            }
        }
    }
}
