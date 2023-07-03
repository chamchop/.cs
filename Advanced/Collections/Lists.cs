namespace Advanced.Collections
{
    public class Lists
    {
        public static void Print()
        {
            List<int> list = new List<int>() { 40, 95, 74, 23, 15, 81 };
            bool b = list.Exists(element => element < 35);
            if (b == true)
            {
                Console.WriteLine("Failed");
            }
            else Console.WriteLine("Passed");

            int firstFailure = list.Find(m => m < 35);
            Console.WriteLine(firstFailure);

            int firstFailureIndex = list.FindIndex(m => m < 35);
            Console.WriteLine(firstFailureIndex);

            int lastFailureIndex = list.FindLast(m => m < 35);
            Console.WriteLine(lastFailureIndex);

            Console.WriteLine("Failed:");
            List<int> findAll= list.FindAll(m => m < 35);
            foreach (int element in findAll)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Convert");
            List<string> strCollection = list.ConvertAll<string>((n) => 
            { 
                return Convert.ToString(n);
            });

            foreach (string element in strCollection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
