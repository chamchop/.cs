using System.Linq.Expressions;

namespace Advanced.Events
{
    public class ExpressionTree
    {
        class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }


            public static void Tree()
            {
                Student student = new Student() { StudentId = 101, StudentName = "Scott", Age = 15 };

                Expression<Func<Student, bool>> expression = st => st.Age > 12 && st.Age < 20;

                Func<Student, bool> myDelegate = expression.Compile();

                bool result = myDelegate.Invoke(student);

                Console.WriteLine(result);
            }
        }
    }
}
