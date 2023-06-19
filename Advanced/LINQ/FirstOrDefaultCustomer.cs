using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.LINQ
{
    public class FirstOrDefaultCustomer
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
                };

                // WHERE
                List<Customer> customerWhere = customers.Where(emp => emp.Job == "Manager").ToList();
                Console.WriteLine(customerWhere[0].Id + " " + customerWhere[0].Id);

                // FIRST
                Customer customerFirst = customers.First(emp => emp.Job == "Manager");                            
                Console.WriteLine(customerFirst.Name + " " + customerFirst.Id);

                // FIRSTORDEFAULT
                Customer customerFirstOrDefault = customers.FirstOrDefault(emp => emp.Job == "Banker");
                if (customerFirstOrDefault != null)
                {
                    Console.WriteLine(customerFirstOrDefault.Name + " " + customerFirstOrDefault.Id);
                }
                else Console.WriteLine("null");
            }
        }
    }
}
