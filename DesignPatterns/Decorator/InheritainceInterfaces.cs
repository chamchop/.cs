namespace DesignPatterns.Decorator
{
    public class InheritainceInterfaces
    {
        public interface IBird
        {
            public int Weight { get; set; }

            void Fly();
        }

        public class Bird : IBird
        {
            public int Weight { get; set; }

            public void Fly()
            {
                Console.WriteLine($"flying with weight {Weight}");

            }
        }

        public interface ILizard
        {
            public int Weight { get; set; }

            void Crawl();
        }

        public class Lizard : ILizard
        {
            public int Weight { get; set; }

            public void Crawl()
            {
                Console.WriteLine($"crawling with weight {Weight}");
            }
        }

        public class Dragon : IBird, ILizard
        {
            private Bird bird = new Bird();
            private ILizard lizard = new Lizard();
            private int weight;
            public int Weight
            {
                get { return weight; }
                set
                {
                    weight = value;
                    bird.Weight = value;
                    lizard.Weight = value;
                }
            }

            public Dragon()
            {

            }

            public void Fly()
            {
                lizard.Crawl();
            }

            public void Crawl()
            {
                bird.Fly();
            }
        }
    }
}
