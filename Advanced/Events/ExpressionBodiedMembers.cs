namespace Advanced.Events
{
    public class Student
    {
        private string _studentName;

        public int GetStudentNameLength()
        {
            return _studentName.Length;
        }

        public int GetStudNameLength() => _studentName.Length;

        public Student() => _studentName = "John";

        public string StudentName
        {
            set => _studentName = value;
            get => _studentName;
        }
    }

    public class ExpressionBodiedMembers
    {

    }
}
