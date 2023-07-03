namespace Advanced.Misc
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
