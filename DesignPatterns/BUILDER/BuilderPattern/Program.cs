using System.Text;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public class HtmlElement
    {
        public string Name { get; init; }
        public string? Text { get; set; }

        public List<HtmlElement> Elements = [];
        private const int indentSize = 2;

        public HtmlElement() { }

        public HtmlElement(string name, string text)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(text);

            Name = name;
            Text = text;
        }

        public override string ToString()
        {
            StringBuilder message = new();
            string indent = new(' ', indentSize);
            message.AppendLine($"{indent}<{Name}>");

            message.Append(new string(' ', indentSize + 1));
            message.AppendLine(Text);

            foreach (HtmlElement element in Elements)
            {
                message.Append(element.ToString());
            }

            message.AppendLine($"{indent}</{Name}>");

            return message.ToString();
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        public HtmlElement root;

        public HtmlBuilder(string rootName)
        {
            rootName = rootName;
            root = new HtmlElement() { Name = rootName };
        }

        public HtmlBuilder(string rootName, string rootText)
        {
            rootName = rootName;
            root = new HtmlElement(rootName, rootText);
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            HtmlElement item = new HtmlElement(childName, childText);
            root.Elements.Add(item);

            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement() { Name = rootName };
        }
    }
}
