namespace Advanced.Events
{
    public class PredicateDelegate
    {
        public event Predicate<int> myPredicate;

        public bool RaiseEvent(int a)
        {
            if (this.myPredicate != null)
            {
                bool result = this.myPredicate(a);
                return result;
            }
            else return false;
        }
    }
}