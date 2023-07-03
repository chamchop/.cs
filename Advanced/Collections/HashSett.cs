namespace Advanced.Collections
{
    public class HashSett
    {
        public static void HashSets()
        {
            HashSet<string> messages = new HashSet<string>() 
            {
                "Hello", "Hi", "Hey"
            };

            messages.Add("Heya");

            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            messages.RemoveWhere(m => m.StartsWith("Y"));

            Console.WriteLine("Count: " + messages.Count);

            messages.Remove("Hi");

            messages.RemoveWhere(m => false);

            Console.WriteLine("Count: " + messages.Count);

            bool hello = messages.Contains("Hello");
            Console.WriteLine("Contains: " + hello);

            HashSet<string> one = new HashSet<string>() { "Tim", "Tom", "Tam" };
            HashSet<string> two = new HashSet<string>() { "Tam", "Pam", "Pat", "Pip" };

            one.UnionWith(two);

            foreach (string item in two)
            {
                Console.WriteLine("Union: " + item);
            }

            one.IntersectWith(two);

            foreach (string item in one)
            {
                Console.WriteLine("Intersect: " + item);
            }
        }
    }
}
