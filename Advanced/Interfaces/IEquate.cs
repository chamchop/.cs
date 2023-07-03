namespace Advanced.Interfaces
{
    public class IEquate : IEquatable<IEquate>
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }

        public bool Equals(IEquate? other)
        {
            return this.CustomerID == other.CustomerID &&
                this.CustomerName == other.CustomerName &&
                this.Email == other.Email;
        }
    }
}
