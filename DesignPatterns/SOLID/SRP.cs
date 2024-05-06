namespace SOLID.SOLID
{
    internal class SRP
    {
        public class Journal
        {
            private readonly List<string> entry = new List<string>();
            private static int count = 0;

            public int AddEntry(string text)
            {
                entry.Add($"{++count}: {text}");
                return count;
            }

            public void RemoveEntry(int index)
            {
                entry.RemoveAt(index);
            }

            public void ReadEntry() => Console.WriteLine(entry);

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entry);
            }
        }
        public class JournalIO
        {
            public void WriteEntry(Journal j, string filename, bool overwrite = false)
            {
                if (overwrite || !File.Exists(filename)) File.WriteAllText(filename, ToString());
            }

            public void SaveEntry()
            {
                var journal = new Journal();
                journal.AddEntry("text");
                journal.AddEntry("texting");

                var save = new JournalIO();
                save.WriteEntry(journal, @"c:\test.txt");
            }

            public static void Print()
            {
                var entry = new JournalIO();
                entry.SaveEntry();
                var journal = new Journal();
                journal.ReadEntry();
            }
        }
    }
}
