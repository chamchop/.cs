namespace Advanced.Events
{
    public class FuncDelegate
    {
        public event Func<int, int, int> myEvents;

        public int RaiseEvent(int a, int b)
        {
            if (this.myEvents != null)
            {
                int x = this.myEvents(a, b);
                return x;
            }
            else return 0;
        }
    }
}
