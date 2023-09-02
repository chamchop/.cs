namespace DesignPatterns.Singleton
{
    public class Monostate
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name; set => name = value;
        }

        public int Age
        {
            get => age; set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }

        public static void Exe()
        {
            var monostate = new Monostate();
            monostate.Name = "Adam Smith";
            monostate.Age = 50;
            var monostate2 = new Monostate();
            Console.WriteLine(monostate2);
        }
    }
}
