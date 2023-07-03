namespace Advanced.Interfaces
{
    public class IEnumerate
    {
        public static void Print()
        {
            IEnumerable<string> messages = new List<string>() { "Hello", "Hi", "Heya" };
            
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            IEnumerator<string> enumerator = messages.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
