namespace Advanced.Misc
{
    public class ParameterModifier
    {
        public double CalculateTaxRef(ref double percentage)
        {
            double t;
            percentage = 10.45;
            int cost = 500;

            if (cost <= 20000)
            {
                t = cost * 10 / 100;
            }
            else
            {
                t = cost * percentage / 100;
            }
            return t;
        }

        public double CalculateTaxOut(out double percentage)
        {
            double t;
            percentage = 10.45;
            int cost = 100;

            if (cost <= 20000)
            {
                t = cost * 10 / 10;
            }
            else
            {
                t = cost * percentage / 10;
            }
            return t;
        }

        public double CalculateTaxIn(in double percent)
        {
            double t;
            int cost = 100;

            if (cost <= 20000)
            {
                t = cost * 10 / 10;
            }
            else
            {
                t = cost * percent / 10;
            }
            return t;
        }

        public static void Print()
        {
            ParameterModifier one = new ParameterModifier();
            double p = 20;
            Console.WriteLine(one.CalculateTaxRef(ref p));
            Console.WriteLine(p);

            /*            ParameterModifier two = new ParameterModifier();
                        double q = 30;
                        Console.WriteLine(two.CalculateTaxOut(out q));

                        Console.WriteLine(q);*/

            ParameterModifier three = new ParameterModifier();
            double r = 40;
            Console.WriteLine(three.CalculateTaxIn(in r));
            Console.WriteLine(r);

            Student four = new Student();
            four.PrintGrade();

            ref int g = ref four.DoWork();

            g = 5;

            four.PrintGrade();

            ParameterModifier five = new ParameterModifier();
            five.DisplaySubjects("A", "B", "C");
        }

        public void DisplaySubjects(params string[] subjects)
        {
            for(int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine(subjects[i]);
            }
        }
    }

    class Student
    {
        public int grade = 2;

        public void PrintGrade()
        {
            Console.WriteLine(grade);
        }

        public ref int DoWork()
        {
            return ref grade;
        }
    }
}
