using static Advanced.Generics.Methods;

namespace Advanced.Generics
{
    internal class Printing
    {
        public static void Print()
        {
            User<int, int> user = new User<int, int>();
            User<bool, string> user2 = new User<bool, string>();

            user.RegistrationStatus = 1234;
            user2.RegistrationStatus = false;

            user.Age = 22;
            user2.Age = "30-45";

            Console.WriteLine(user.RegistrationStatus);
            Console.WriteLine(user.Age);
            Console.WriteLine(user2.RegistrationStatus);
            Console.WriteLine(user2.Age);


            GradesPrinter<GraduateStudent> grad = new GradesPrinter<GraduateStudent>();
            grad.student = new GraduateStudent() { Grades = 80 };
            grad.PrintGrades();

            Sample sample = new Sample();
            Employee employee = new Employee();
            Methods.Student student = new Methods.Student();

            sample.PrintData<Employee>(employee);
            sample.PrintData<Methods.Student>(student);
        }
    }
}
