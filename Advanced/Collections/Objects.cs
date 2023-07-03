namespace Advanced.Collections
{
    public class Objects
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public DateTime Date { get; set; }

        public static void obj()
        {
            List<Objects> list = new List<Objects>();

            string choice;

            do
            {
                Console.Write("Enter Product ID: ");
                int pid = int.Parse(Console.ReadLine());
                Console.Write("Enter Produce Name: ");
                string pname = Console.ReadLine();
                Console.Write("Enter Price: ");
                double unitPrice = double.Parse(Console.ReadLine());
                Console.Write("Enter Data: ");
                DateTime dom = DateTime.Parse(Console.ReadLine());

                Objects obj = new Objects() { ProductID = pid, ProductName = pname, ProductPrice = unitPrice, Date = dom };

                list.Add(obj);

                Console.WriteLine("Product Added.\n");
                Console.WriteLine("Continue? Yes/No");
                choice = Console.ReadLine();

            } while (choice != "No");

            foreach (Objects obj in list)
            {
                Console.WriteLine(obj.ProductID);
            }
        }
    }
}
