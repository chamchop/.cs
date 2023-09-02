using Autofac;
using Autofac.Features.Metadata;

namespace DesignPatterns.Adapter
{
    public interface ICommand
    {
        void Execute();
    }

    public class DIAdapter
    {

        class SaveCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Saving");
            }
        }

        class OpenCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Opening");
            }
        }

        public class Button
        {
            private ICommand command;
            private string name;

            public Button(ICommand command, string name)
            {
                if (command == null)
                {
                    throw new ArgumentNullException(paramName: nameof(command));
                }
                this.command = command;
                this.name = name;
            }

            public void Click()
            {
                command.Execute();
            }

            public void Print()
            {
                Console.WriteLine($"I am a button called {name}");
            }
        }

        public class Editor
        {
            private IEnumerable<Button> buttons;

            public IEnumerable<Button> Buttons => buttons;

            public Editor(IEnumerable<Button> buttons)
            {
                this.buttons = buttons;
            }

            public void ClickAll()
            {
                foreach (var btn in buttons)
                {
                    btn.Click();
                }
            }
        }

        public class Program
        {
            public static void Exe()
            {
                var b = new ContainerBuilder();
                b.RegisterType<SaveCommand>().As<ICommand>()
                    .WithMetadata("Name", "Save");
                b.RegisterType<OpenCommand>().As<ICommand>()
                    .WithMetadata("Name", "Open");
                b.RegisterAdapter<Meta<ICommand>, Button>(cmd => 
                    new Button(cmd.Value, (string)cmd.Metadata["Name"]));
                b.RegisterType<Editor>();

                using (var c = b.Build())
                {
                    var editor = c.Resolve<Editor>();
/*                    editor.ClickAll();*/

                    foreach (var btn in editor.Buttons) { btn.Print(); }
                }
            }
        }
    }
}
