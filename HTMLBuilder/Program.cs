using DesignPatternBuilder;
using System.Text;
using static System.Console;

public class Demo
{
    static void Main(string[] args)
    {
        #region HtmlBuilder
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
        #endregion

        #region StepwiseBuilder-Car
        var car = CarBuilder.Create()  //ISpecifyCarType
            .OfType(CarType.Crossover) //ISpecifyWheelSize
            .WithWheels(18)            //IBuildCar
            .Build(true);

        #endregion
    }
}