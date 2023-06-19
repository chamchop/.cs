namespace Advanced.LINQ
{
    public class OrderByCustomer
    {
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
            public int Salary { get; set; }

            public static void Print()
            {
                List<Customer> customers = new List<Customer>()
        {
                    new Customer() { Id = 1, Name = "Joe", Job = "Designer", Salary = 10000 },
                    new Customer() { Id = 2, Name = "Jack", Job = "Developer", Salary = 20000 },
                    new Customer() { Id = 3, Name = "Jill", Job = "Analyst", Salary = 10000 },
                    new Customer() { Id = 4, Name = "Jane", Job = "Manager", Salary = 20000 },
                    new Customer() { Id = 5, Name = "Jim", Job = "Developer", Salary = 15000 },
        };

                IOrderedEnumerable<Customer> customer = customers.OrderByDescending(emp => emp.Job)
                    .ThenBy(emp => emp.Salary).ThenByDescending(emp => emp.Id);
                

                foreach (Customer item in customer)
                {
                    Console.WriteLine(item.Id + ", " + item.Name + ", " + item.Job + ", " + item.Salary);
                }

            }
        }
    }
}
