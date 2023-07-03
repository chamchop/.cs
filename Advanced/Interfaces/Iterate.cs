namespace Advanced.Interfaces
{
    public class Iterate
    {
        public static void Print()
        {
            Sample s = new Sample();
            var enumeration = s.Method();
            var enumer = enumeration.GetEnumerator();
            enumer.MoveNext();
            Console.WriteLine(enumer.Current);
            enumer.MoveNext();
            Console.WriteLine(enumer.Current);
        }
    }

    public class Sample
    {
        public List<double> Prices { get; set; } = new List<double>() { 90, 34, 12, 80 };

        public IEnumerable<double> Method()
        {
            /*            Console.WriteLine("Iterator method executes");
                        yield return 10;
                        Console.WriteLine("Continue");
                        yield return 20;*/

            double sum = 0;
            foreach (double price in Prices)
            {
                sum += price;
                yield return sum;
            }
        }
    }
}
