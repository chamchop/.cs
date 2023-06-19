using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Generics
{
    public class Constraints
    {
    }

    public class GradesPrinter<T> where T : Student
    {
        public T student;

        public void PrintGrades()
        {
            Student temp = (Student)student;
            Console.WriteLine(temp.Grades);
        }
    }

    public class GraduateStudent : Student
    {
        public override int Grades { get; set; }
    }

    public class PostGraduateStudent : Student
    {
        public override int Grades { get; set; }
    }

    public abstract class Student
    {
        public abstract int Grades { get; set; }
    }
}
