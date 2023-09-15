using DesignPatterns.Composite;

namespace DesignPatterns.Decorator
{
    public class StaticDecorator
    {
        public abstract class Shape
        {
            public abstract string AsString();
        }

        public class ColouredShape<T> : Shape where T : Shape, new()
        {
            private string colour;
            private T shape = new T();

            public ColouredShape() : this("black")
            {
            }

            public ColouredShape(string colour)
            {
                this.colour = colour ?? throw new ArgumentNullException(paramName: nameof(colour));
            }

            public override string AsString()
            {
                return colour;
            }
        }

        public class TransparentShape<T> : Shape where T : Shape, new()
        {
            private float transparency;
            private T shape = new T();

            public TransparentShape() : this(0)
            {
            }

            public TransparentShape(float transparency)
            {
                this.transparency = transparency;
            }

            public override string AsString()
            {
                return $"has {transparency}";
            }
        }

        public static void Print()
        {
            /*            var redSquare = new ColouredShape<Square>("red");
                        Console.WriteLine(redSquare.AsString());*/

            /*            var circle = new TransparentShape<ColouredShape<Circle>>(0.4f);
                        Console.WriteLine(circle.AsString());*/
        }
    }
}
