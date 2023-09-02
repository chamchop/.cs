using System.Text;

namespace DesignPatterns.Composite
{
    public class GraphicObject
    {
        public string Colour;
        public virtual string Name { get; set; } = "Group";
        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth)).AppendLine(string.IsNullOrWhiteSpace(Colour) ? string.Empty : $"{Colour}").AppendLine(Name);

            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

        public static void Program()
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Colour = "Red" });
            drawing.Children.Add(new Circle { Colour = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Square { Colour = "Blue" });
            group.Children.Add(new Circle { Colour = "Blue" });
            
            drawing.Children.Add(group);
            Console.WriteLine(drawing);
        }
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }
}
