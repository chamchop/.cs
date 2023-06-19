using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class DynamicTyping
    {

        public static void Print()
        {
            dynamic x;
            x = 100;
            Console.WriteLine(x);
            x = "Hello";
            Console.WriteLine(x);
            x = new Student() { name = "Joe" };
            Console.WriteLine(x.name);
        }

        class Student
        {
            public string name { get; set; }
        }

    }
}
