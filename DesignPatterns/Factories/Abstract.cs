namespace DesignPatterns.Factories
{
    public class Abstract
    {

        public interface IHotDrink
        {
            void Consume();
        }

        internal class Tea : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("");
            }
        }

        internal class Coffee : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("");
            }
        }

        public interface IHotDrinkFactory
        {
            IHotDrink Prepare(int amount);
        }

        internal class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                return new Tea();
            }
        }

        internal class CoffeeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                return new Coffee();
            }
        }

        public class HotDrinkMachine
        {

            private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

            public HotDrinkMachine()
            {
                foreach (var element in typeof(HotDrinkMachine).Assembly.GetTypes())
                {
                    if (typeof(IHotDrinkFactory).IsAssignableFrom(element) &&
                            !element.IsInterface)
                    {
                        factories.Add(Tuple
                            .Create(element.Name
                            .Replace("Factory", string.Empty),
                            (IHotDrinkFactory)Activator
                            .CreateInstance(element)
                            ));
                    }
                }
            }

            public IHotDrink MakeDrink()
            {
                Console.WriteLine("Available Drinks: ");
                for (var index = 0; index < factories.Count; index++)
                {
                    var tuple = factories[index];
                    Console.WriteLine($"{index}: {tuple.Item1}");
                }

                while (true)
                {
                    string s;
                    if ((s = Console.ReadLine()) != null
                        && int.TryParse(s, out int i)
                        && i >= 0
                        && i < factories.Count)
                    {
                        Console.WriteLine("Specify Amount: ");
                        s = Console.ReadLine();

                        if (s != null
                            && int.TryParse(s, out int amount)
                            && amount > 0)
                        {
                            return factories[i].Item2.Prepare(amount);
                        }
                    }
                    Console.WriteLine("Error");
                }
            }
        }

        /*            public enum AvailableDrink
                    {
                        Coffee, Tea
                    }*/

        /*            private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

                    public HotDrinkMachine()
                    {
                        foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
                        {
                            var factory = (IHotDrinkFactory)Activator
                                .CreateInstance(Type
                                .GetType("Design Patterns" + Enum.
                                GetName(typeof(AvailableDrink), drink) + "Factory")
                                );
                            factories.Add(drink, factory);
                        }
                    }

                    public IHotDrink MakeDrink(AvailableDrink drink, int amount)
                    {
                        return factories[drink].Prepare(amount);
                    }*/

        public static void Exe()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}