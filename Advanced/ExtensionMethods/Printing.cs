using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.ExtensionMethods
{
    internal class Printing
    {
        public static void Print()
        {
            Product one = new Product() { ProductCost = 1000, DiscountPercentage = 10 };
            Console.WriteLine(one.GetDiscount());   
        }
    }
}
