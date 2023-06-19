namespace Advanced.Events
{
    public class AutoImplementedEvent
    {
        public event MyDelegateType myAutoEvent;

        public void RaiseAutoEvent(int a, int b)
        {
            if (this.myAutoEvent != null)
            {
                this.myAutoEvent(a, b);
            }
        }
    }
}
