using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.LINQ
{
    public class Arithmetic
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

                double min = customers.Min(c => c.Salary);
                double max = customers.Max(c => c.Salary);
                double sum = customers.Sum(c => c.Salary);
                double avg = customers.Average(c => c.Salary);
                Console.WriteLine(min);
                Console.WriteLine(max);
                Console.WriteLine(sum);
                Console.WriteLine(avg);
            }
        }
    }
}
