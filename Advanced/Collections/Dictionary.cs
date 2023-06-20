using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Collections
{
    public class Dictionary
    {
        public static void Diction()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>()
            {
                { 101, "Scott" },
                { 102, "Steve" },
                { 103, "Simon" },
                { 104, "Sean" }
            };

            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine(employee.Key + ", " + employee.Value);
            }

            string s = employees[101];
            Console.WriteLine("Value at 101: " + s);

            Dictionary<int, string>.KeyCollection keys = employees.Keys;

            foreach(int item in keys)
            {
                Console.WriteLine(item);
            }

            bool keyFlag = employees.ContainsKey(103);
            Console.WriteLine(keyFlag);

            bool valueFlag = employees.ContainsValue("Scott");
            Console.WriteLine(valueFlag);


        }
    }
}
