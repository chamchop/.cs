namespace SOLID.SOLID
{
    internal class ISP
    {
        public interface IMachine
        {
            public void Print(Document d);
            public void Scan(Document d);
            public void Fax(Document d);

        }

        public class Printer : IMachine
        {
            void IMachine.Fax(Document d)
            {
                throw new NotImplementedException();
            }

            void IMachine.Print(Document d)
            {
                throw new NotImplementedException();
            }

            void IMachine.Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public interface IPrinter
        {
            void Print(Document d);
        }

        public interface IScanner
        {
            void Scan(Document d);
        }

        public interface IPhotocopier : IPrinter, IScanner
        {

        }

        public class Photocopier : IPhotocopier
        {
            void IPrinter.Print(Document d)
            {
                throw new NotImplementedException();
            }

            void IScanner.Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public class Document
        {

        }

        public class Print
        {
            public static void Exe()
            {

            }
        }
    }
}
