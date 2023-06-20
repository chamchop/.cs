namespace Advanced.Collections
{
    public class SortedList
    {
        public static void SortList()
        {
            SortedList<int, string> employees = new SortedList<int, string>()
            {
                { 104, "Jones" },
                { 103, "Allen" },
                { 102, "Smith" },
                { 101, "Scott" },
                { 105, "James" }
            };

            employees.Add(106, "Anna");
            employees.Remove(103);

            foreach (KeyValuePair<int, string> item in employees)
            {
                Console.WriteLine(item);
            }

            string eName = employees[105];
            Console.WriteLine(eName);

            bool flagKey = employees.ContainsKey(105);
            Console.WriteLine(flagKey);

            bool flagValue = employees.ContainsValue("Scott");
            Console.WriteLine(flagValue);

            int flagKeyIndex = employees.IndexOfKey(105);
            Console.WriteLine(flagKeyIndex);

            foreach (int item in employees.Keys)
            {
                Console.WriteLine(item);
            }
        }
    }
}
