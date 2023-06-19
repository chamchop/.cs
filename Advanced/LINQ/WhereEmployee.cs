namespace Advanced.LINQ
{
    public class WhereEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string City { get; set; }

        public static void Print()
        {
            List<WhereEmployee> employees = new List<WhereEmployee>()
        {
            new WhereEmployee() { Id = 1, Name = "Joe", Job = "Designer", City = "London" },
            new WhereEmployee() { Id = 2, Name = "Jack", Job = "Developer", City = "Birmingham" },
            new WhereEmployee() { Id = 3, Name = "Jill", Job = "Analyst", City = "Edinburgh" },
            new WhereEmployee() { Id = 4, Name = "Jane", Job = "Manager", City = "Manchester" },
            new WhereEmployee() { Id = 5, Name = "Jim", Job = "Developer", City = "Newcastle" },
        };

            IEnumerable<WhereEmployee> result = employees.Where(emp => emp.Job == "Developer");
            foreach(WhereEmployee item in result)
            {
                Console.WriteLine(item.Id + ", " + item.Name + ", " + item.Job + ", " + item.City);
            }
        }
    }

    class Temporary
    {
        public bool Check(WhereEmployee emp)
        {
            return emp.Job == "Manager";
        }
    }
}