using System.Drawing;
using System.Text;
using static DesignPatterns.Decorator.DecoratorCycles;
using static DesignPatterns.Decorator.StaticDecorator;

namespace DesignPatterns.Decorator
{
    public class DynamicComposition
    {
        public interface IShape
        {
            string AsString();
        }

        public abstract class ShapeDecorator : IShape
        {

            protected internal readonly List<Type> types = new();
            protected internal IShape shape;

            public ShapeDecorator(IShape shape)
            {
                this.shape = shape;
                if (shape is ShapeDecorator sd)
                {
                    types.AddRange(sd.types);
                }
            }

            public string AsString()
            {
                return $"{shape.AsString()} has colour {shape}";
            }
        }

        public abstract class ShapeDecorator<TSelf, TCyclePolicy> :
            ShapeDecorator where TCyclePolicy : ShapeDecoratorCyclePolicy, new()
        {
            protected readonly TCyclePolicy policy = new();

            protected ShapeDecorator(IShape shape) : base(shape)
            {
                if (policy.TypeAdditionAllowed(typeof(TSelf), types))
                    types.Add(typeof(TSelf));
            }
        }

        public class ShapeDecoratorWithPolicy<T> : ShapeDecorator<T, ThrowOnCyclePolicy>
        {
            public ShapeDecoratorWithPolicy(IShape shape) : base(shape)
            {

            }
        }

        public class ColouredShape : ShapeDecorator<ColouredShape, CyclesAllowedPolicy>
        {
            private IShape shape;
            private string colour;

            public ColouredShape(IShape shape, string colour) : base(shape)
            {
                this.shape = shape ?? throw new ArgumentNullException("shape");
                this.colour = colour ?? throw new ArgumentNullException("colour");
            }

            public string AsString()
            {
                var stringBuilder = new StringBuilder($"{shape.AsString()}");
                if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList())) 
                    stringBuilder.Append($"has {colour}");
                return $"{shape.AsString()} has colour {colour}";
            }
        }

        public class Circle : IShape
        {
            private float radius;

            public Circle() : this(0)
            {
                
            }

            public Circle(float radius)
            {
                this.radius = radius;
            }

            public void Resize(float factor)
            {
                this.radius *= factor;
            }

            public string AsString() => $"radius: {radius}";
        }

        public class Square : Shape
        {
            private float side;

            public Square() : this(0.0f)
            {                
            }

            public Square(float side)
            {
                this.side = side;
            }

            public override string AsString() => $"side: {side}";
        }

/*        public class ColouredShape : IShape
        {
            private IShape shape;
            private string colour;

            public ColouredShape(IShape shape, string colour)
            {
                this.shape = shape ?? throw new ArgumentNullException("shape");
                this.colour = colour ?? throw new ArgumentNullException("colour");
            }

            public string AsString()
            {
                return $"{shape.AsString()} has colour {colour}";
            }
        }*/

        public class TransparentShape : IShape
        {
            private IShape shape;
            private float transparency;

            public TransparentShape(IShape shape, float transparency)
            {
                this.shape = shape ?? throw new ArgumentNullException("shape");
                this.transparency = transparency;
            }

            public string AsString()
            {
                return $"{shape.AsString()} has transparency {transparency * 100.00}%";
            }
        }

        public static void Print()
        {
            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());

/*            var redSquare = new ColouredShape(square, "red");
            Console.WriteLine(redSquare.AsString());*/

/*            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            Console.WriteLine(redHalfTransparentSquare.AsString());*/
        }
    }
}