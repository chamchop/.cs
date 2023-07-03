namespace Advanced.Interfaces
{
    public class ICompare
    {
        public static void Print()
        {
            List<int> numbers = new List<int>() { 80, 12, 77, 34 };
            
            numbers.Sort();
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {EmployeeId = 1, EmployeeName = "Tom", Job = "Developer" },
                new Employee() {EmployeeId = 2, EmployeeName = "Dick", Job = "Manager" },
                new Employee() {EmployeeId = 3, EmployeeName = "Harry", Job = "Designer" }
            };

            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.EmployeeName);
            }

            Employee one = new Employee();
            one.CompareTo(one);
        }

        class Employee : IComparable
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Job { get; set; }

            public int CompareTo(object other)
            {
                Employee otherEmp = (Employee)other;
                Console.WriteLine(this.EmployeeId + ", " + ((Employee)other).EmployeeId);
                return this.EmployeeId - otherEmp.EmployeeId;
            }
        }
    }
}
