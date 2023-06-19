using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.LINQ
{
    public class ElementAt
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
                    new Customer() { Id = 7, Name = "Joan", Job = "Manager", Salary = 10000 },
                };

                // ELEMENTAT
                Customer customAt = customers.Where(cus => cus.Job == "Developer").ElementAt(1);
                Console.WriteLine(customAt.Id + " " + customAt.Name);

                // FIRSTORDEFAULT
                Customer customAtOrDefault = customers.Where(cus => cus.Job == "Developer").ElementAtOrDefault(10);
                if (customAtOrDefault != null)
                {
                    Console.WriteLine(customAtOrDefault.Name + " " + customAtOrDefault.Salary);
                }
                else Console.WriteLine("null");            
            }
        }
    }
}
