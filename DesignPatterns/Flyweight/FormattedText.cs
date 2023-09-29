using JetBrains.dotMemoryUnit;
using System.Text;

namespace DesignPatterns.Flyweight
{
    public class FormattedText
    {
        private readonly string plainText;
        private bool[] capitalise;

        public FormattedText(string plainText)
        {
            this.plainText = plainText;
            capitalise = new bool[plainText.Length];
        }

        public void Capitalise(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                capitalise[i] = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < capitalise.Length; i++)
            {
                var c = plainText[i];
                sb.Append(capitalise[i] ? char.ToUpper(c) : c);
            }
            return sb.ToString();
        }

        public static void Print()
        {
            var ft = new FormattedText("string");
            ft.Capitalise(0, 6);
            Console.WriteLine(ft);
        }
    }

    public class BetterFormattedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();

        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText;
        }

        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange { Start = start, End = end };
            formatting.Add(range);
            return range;
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalise, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formatting)
                {
                    if (range.Covers(i) && range.Capitalise)
                    {
                        c = char.ToUpper(c);
                    }
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static void Print()
        {
            var ft = new FormattedText("string");
            ft.Capitalise(0, 6);
            Console.WriteLine(ft);

            var bft = new BetterFormattedText("string");
            bft.GetRange(0, 6).Capitalise = true;
            Console.WriteLine(bft);
        }
    }
}
