using static SOLID.SOLID.OCP;

namespace SOLID.SOLID
{
    internal class OCP
    {
        public enum Colour
        {
            Red, Green, Blue
        }

        public enum Size
        {
            Small, Medium, Large
        }
        public class Product
        {
            public string Name { get; set; }
            public Colour Colour { get; set; }
            public Size Size { get; set; }

            public Product(string name, Colour colour, Size size)
            {
                Name = Name; Colour = Colour; Size = Size;
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filters(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class ColourSpecification : ISpecification<Product>
        {
            private Colour colour;

            public ColourSpecification(Colour colour)
            {
                this.colour = colour;
            }

            public bool IsSatisfied(Product t)
            {
                return t.Colour == colour;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;

            public SizeSpecification(Size size)
            {
                this.size = size;
            }

            public bool IsSatisfied(Product t)
            {
                return t.Size == size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first;
                this.second = second;
            }

            public bool IsSatisfied(T t)
            {
                return first.IsSatisfied(t) && second.IsSatisfied(t);
            }
        }

        public class Filter : IFilter<Product>
        {
            public IEnumerable<Product> Filters(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var i in items)
                    if (spec.IsSatisfied(i))
                        yield return i;
            }
        }

        public class Print
        {
            public static void Printing()
            {
                var apple = new Product("apple", Colour.Red, Size.Small);
                var tree = new Product("tree", Colour.Green, Size.Medium);
                var house = new Product("house", Colour.Blue, Size.Large);

                Product[] products = { apple, tree, house };

                var filter = new Filter();
                foreach (var item in filter.Filters(products, new ColourSpecification(Colour.Green)))
                {
                    Console.WriteLine(item.Name);
                }

                foreach (var item in filter.Filters(products, new AndSpecification<Product>
                    (new ColourSpecification(Colour.Blue), new SizeSpecification(Size.Large))))
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
