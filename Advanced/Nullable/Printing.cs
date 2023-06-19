using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Nullable
{
    public class Printing
    {
        public static void Print()
        {
            Person one = new Person() { number = 2 };
            Person two = new Person() { id = 5 };
            Person three = new Person() { age = null };

            if (three.age.HasValue)
            {
                Console.WriteLine((one == null) ? null : Convert.ToString(one.number));
                Console.WriteLine(one?.number);
                Console.WriteLine((two.id.HasValue) ? two.id.Value : 0);
                Console.WriteLine(two.id ?? 0);
                Console.WriteLine(three.age.Value);
            }
        }
    }
}
