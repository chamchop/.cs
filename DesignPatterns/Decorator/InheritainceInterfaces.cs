namespace DesignPatterns.Decorator
{
    public class InheritainceInterfaces
    {

        public interface ICreature
        {
            int Age { get; set; }
        }

        public interface IBird : ICreature
        {
            public int Weight { get; set; }

            void Fly()
            {
                if (Age  > 10)
                {
                    Console.WriteLine("Flying");
                }
            }                
        }

        public class Bird : IBird
        {
            public int Weight { get; set; }
            public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void Fly()
            {
                Console.WriteLine($"flying with weight {Weight}");

            }
        }

        public interface ILizard : ICreature
        {
            public int Weight { get; set; }

            void Crawl()
            {
                if (Age > 10)
                {
                    Console.WriteLine("Crawling");
                }
            }
        }

        public class Lizard : ILizard
        {
            public int Weight { get; set; }
            public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void Crawl()
            {
                Console.WriteLine($"crawling with weight {Weight}");
            }
        }

        public class Organism {}

        public class Dragon : Organism, ICreature
        {
            public int Age { get; set; }
        }

        public static void Species()
        {
            Dragon dragon = new Dragon { Age = 5 };

            if (dragon is IBird bird)
            {
                bird.Fly();
            }

            if (dragon is ILizard lizard)
            {
                lizard.Crawl();
            }

        }
    }
}

/*        public class Dragon : ICreature
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

            public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        }*/
