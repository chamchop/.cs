using static Advanced.Delegates.MyDelegate;

namespace Advanced.Delegates
{
    public class SingleCastDelegate
    {

        public int Add(int a, int b) { int c = a + b; return c; }

        public static void Print()
        {
            SingleCastDelegate del = new SingleCastDelegate();

            // add method reference to delegate object
            MyDelegateType myDelegateType = new MyDelegateType(del.Add);

            Console.WriteLine(myDelegateType.Invoke(10, 2));
        }
    }
}
