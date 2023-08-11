using System.Text;

namespace DesignPatterns.Factories
{
    internal class Themes
    {
        public interface ITheme
        {
            string TextColour { get; }
            string BgrColour { get; }
        }

        class LightTheme : ITheme
        {
            public string TextColour => "black";

            public string BgrColour => "white";
        }

        class DarkTheme : ITheme
        {
            public string TextColour => "white";

            public string BgrColour => "dark gray";
        }

        public class TrackingThemeFactory
        {
            private readonly List<WeakReference<ITheme>> themes = new();

            public ITheme CreateTheme(bool dark)
            {
                ITheme theme = dark ? new DarkTheme() : new LightTheme();
                themes.Add(new WeakReference<ITheme>(theme));
                return theme;
            }

            public string Info
            {
                get
                {
                    var sb = new StringBuilder();
                    foreach (var reference in themes)
                    {
                        if (reference.TryGetTarget(out var theme))
                        {
                            bool dark = theme is DarkTheme;
                            sb.Append(dark ? "Dark" : "Light")
                                .AppendLine(" theme");
                        }
                    }

                    return sb.ToString();
                }
            }
        }

        public class ReplaceableThemeFactory
        {
            private readonly List<WeakReference<Ref<ITheme>>> themes = new();

            private ITheme createThemeImpl(bool dark)
            {
                return dark ? new DarkTheme() : new LightTheme();
            }

            public Ref<ITheme> CreateTheme(bool dark)
            {
                var r = new Ref<ITheme>(createThemeImpl(dark));
                themes.Add(new(r));
                return r;
            }

            public void ReplaceTheme(bool dark)
            {
                foreach (var reference in themes)
                {
                    if (reference.TryGetTarget(out var refer))
                    {
                        refer.Value = createThemeImpl(dark);
                    }
                }
            }
        }

        public class Ref<T> where T : class
        {
            public T Value;

            public Ref(T value)
            {
                Value = value;
            }
        }

        public static void Exe()
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(true);
            var theme2 = factory.CreateTheme(false);
            Console.WriteLine(factory.Info);

            var factory2 = new ReplaceableThemeFactory();
            var magicTheme = factory2.CreateTheme(true);
            Console.WriteLine(magicTheme.Value.BgrColour);
            factory2.ReplaceTheme(false);
            Console.WriteLine(magicTheme.Value.BgrColour);
        }
    }
}
