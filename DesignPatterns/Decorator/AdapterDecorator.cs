using System.Text;

namespace DesignPatterns.Decorator
{
    public class AdapterDecorator
    {
        public static void Exe()
        {
            MyStringBuilder s = "hello ";
            s += "world";
            Console.WriteLine(s);
        }
    }

    public class MyStringBuilder
    {
        StringBuilder sb = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.sb.Append(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, string s)
        {
            msb.sb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
