namespace Advanced.Generics
{
    public class Methods
    {
        
        public class Employee
        {
            public int Salary;
        }

        public class Student
        {
            public int Marks;
        }

        public class Sample
        {
            public void PrintData<T>(T obj) where T : class
            {
                if (obj.GetType() == typeof(Student))
                {
                    Student temp = obj as Student;
                    Console.WriteLine(temp.Marks);
                }
                else if (obj.GetType() == typeof(Employee))
                {
                    Employee temp = obj as Employee;
                    Console.WriteLine(temp.Salary);
                }
            }
        }
    }
}
