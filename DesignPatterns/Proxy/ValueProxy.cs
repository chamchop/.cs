using static DesignPatterns.Proxy.ValueProxy;

namespace DesignPatterns.Proxy
{
    public class ValueProxy
    {
        public struct Percentage
        {
            private readonly float value;

            internal Percentage(float value)
            {
                this.value = value;
            }

            public static float operator *(float f, Percentage p)
            {
                return f * p.value;
            }

            public static Percentage operator +(Percentage a, Percentage b)
            {
                return new Percentage(a.value + b.value);
            }

            public static bool operator ==(Percentage left, Percentage right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Percentage left, Percentage right)
            {
                return !left.Equals(right);
            }

            public override string ToString()
            {
                return $"{value * 100}%";
            }

            public bool Equals(Percentage other)
            {
                return value.Equals(other.value);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is Percentage other && Equals(other);
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }
        }
        public static void Print()
        {
            Console.WriteLine(10f * 5.Percent());
            Console.WriteLine(2.Percent() + 3.Percent());
        }
    }


    public static class PercentageExtensions
    {
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }
}
