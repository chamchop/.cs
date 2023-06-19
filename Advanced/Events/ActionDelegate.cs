namespace Advanced.Events
{
    public class ActionDelegate
    {
        public event Action<int, int> myAction;

        public void RaiseEvent(int a, int b)
        {
            if (this.myAction != null)
            {
                this.myAction(a, b);
            }
        }
    }
}
