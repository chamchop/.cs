using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.LINQ
{
    public class LastOrDefaultCustomer
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
                    new Customer() { Id = 5, Name = "Jim", Job = "Developer", Salary = 20000 },
                    new Customer() { Id = 6, Name = "Jon", Job = "Developer", Salary = 25000 },
                };

                // WHERE
                List<Customer> customerWhereLast = customers.Where(emp => emp.Job == "Developer").ToList();
                Console.WriteLine(customerWhereLast[customerWhereLast.Count - 1].Id + " "
                    + customerWhereLast[customerWhereLast.Count - 1].Name);

                // FIRST
                Customer customerLast = customers.Last(emp => emp.Job == "Developer");
                Console.WriteLine(customerLast.Name + " " + customerLast.Id);

                // FIRSTORDEFAULT
                Customer customerLastOrDefault = customers.LastOrDefault(emp => emp.Job == "Developer");
                if (customerLastOrDefault != null)
                {
                    Console.WriteLine(customerLastOrDefault.Name + " " + customerLastOrDefault.Salary);
                }
                else Console.WriteLine("null");
            }
        }
    }
}
