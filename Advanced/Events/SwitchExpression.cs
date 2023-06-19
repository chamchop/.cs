namespace Advanced.Events
{
    public class SwitchExpression
    {
        public void Switch(int a)
        {
            int operation = a;
            string result;

            result = operation switch
            {
                1 => "Customer",
                2 => "Employee",
                3 => "Supplier",
                4 => "Distributor",
                _ => "Invalid"
            };

            Console.WriteLine(result);
        }
    }
}
