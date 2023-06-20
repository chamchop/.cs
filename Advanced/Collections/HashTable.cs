using System.Collections;

namespace Advanced.Collections
{
    internal class HashTable
    {
        public static void HashTab()
        {
            Hashtable hashTable = new Hashtable()
            {
                { 104, "Jones" },
                { 103, "Allen" },
                { 102, "Smith" },
                { 101, "Scott" },
                { 105, "James" },
                { "hello", 106 }
            };

            hashTable.Add(107, "Anna");
            hashTable.Remove(103);

            foreach (DictionaryEntry item in hashTable)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            foreach (var item in hashTable.Values)
            {
                Console.WriteLine(item);
            }

            foreach (var item in hashTable.Keys)
            {
                Console.WriteLine(item);
            }

            if (hashTable[105] is string)
            {
                string value = Convert.ToString(hashTable[105]);
                Console.WriteLine(value);
            }
            else if (hashTable[105] is double)
            {
                string value = Convert.ToString(hashTable[105]);
                Console.WriteLine(value);
            }

            bool k = hashTable.ContainsKey(105);
            Console.WriteLine(k);

            bool v = hashTable.ContainsValue("Scott");
            Console.WriteLine(v);

        }
    }
}

