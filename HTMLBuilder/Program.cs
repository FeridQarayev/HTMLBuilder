using System.Text;
using static System.Console;

public class HtmlElement
{
    public string Name, Text;
    public List<HtmlElement> Elements = new List<HtmlElement>();
    private const int identSize = 2;

    public HtmlElement()
    {

    }

    public HtmlElement(string name, string text)
    {
        Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
    }
    private string ToStringImpl(int ident)
    {
        var sb = new StringBuilder();
        var i = new string(' ', identSize * ident);
        sb.AppendLine($"{i}<{Name}>");

        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', identSize * (ident + 1)));
            sb.AppendLine(Text);
        }

        foreach (var e in Elements)
        {
            sb.Append(e.ToStringImpl(ident + 1));
        }
        sb.AppendLine($"{i}</{Name}>");
        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}

public class HtmlBuilder
{
    private readonly string rootName;
    HtmlElement root = new HtmlElement();

    public HtmlBuilder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }

    public HtmlBuilder AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.Elements.Add(e);
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

public class Demo
{
    static void Main(string[] args)
    {
        //Simple
        var hello = "hello";
        var sb = new StringBuilder();
        sb.Append("<p>");
        sb.Append(hello);
        sb.Append("</p>");
        WriteLine(sb);

        //Midlle
        var words = new[] { "hello", "world" };
        sb.Clear();
        sb.Append("<ul>");
        foreach (var word in words)
        {
            //sb.Append($"<li>{word}</li>");
            sb.AppendFormat("<li>{0}</li>", word);
        }
        sb.Append("</ul>");
        WriteLine(sb);

        //Hard
        var builder = new HtmlBuilder("ul");
        builder.AddChild("li", "hello").AddChild("li", "world");
        WriteLine(builder.ToString());
    }
}