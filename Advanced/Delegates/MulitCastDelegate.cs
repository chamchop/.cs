namespace Advanced.Delegates
{
    public class MulitCastDelegate
    {
        public delegate void MyDelegate(double a, double b);

        public void Add(double a, double b)
        {
            double c = a + b;
            Console.WriteLine(c);
        }

        public void Multiply(double a, double b)
        {
            double c = a * b;
            Console.WriteLine(c);
        }

        public static void Print()
        {
            MulitCastDelegate one = new MulitCastDelegate();
            MyDelegate myDelegate;
            myDelegate = one.Add;
            myDelegate += one.Multiply;
            myDelegate.Invoke(10, 20);
        }
    }
}
