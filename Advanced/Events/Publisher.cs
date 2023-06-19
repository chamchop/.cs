namespace Advanced.Events
{
    public delegate void MyDelegateType(int a, int b);
/*    public delegate int MyDelegateType(int a, int b);*/

    public class Publisher
    {
        private MyDelegateType myDelegate;

        public event MyDelegateType myEvent
        {
            add
            {
                myDelegate += value;
            }
            remove
            {
                myDelegate -= value;
            }
        }

        public void RaiseEvent(int a, int b)
        {
            if (this.myDelegate != null)
            {
                this.myDelegate(a, b);
            }
        }
    }
}
