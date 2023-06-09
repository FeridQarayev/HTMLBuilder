﻿using DesignPatternBuilder.DesignPatterns;
using System.Text;
using static DesignPatternBuilder.DesignPatterns.ClassBuilder;
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
        var car = CarBuilder
            .Create()                  //ISpecifyCarType
            .OfType(CarType.Crossover) //ISpecifyWheelSize
            .WithWheels(18)            //IBuildCar
            .Build(true);

        #endregion

        #region FunctioanlBuilder
        var person = new PersonBuilder()
            .Called("Ferid")
            .WorksAs("Developer")
            .Build();
        #endregion

        #region FacetedBuilder
        var pb = new FacetedBuilder.PersonBuilder();
        FacetedBuilder.Person personn = pb
            .Live.At("123 London Road")
                 .In("London")
                 .WithPostcode("SW12AC")
            .Works.At("Fabrikam")
                  .Asa("Engineer")
                  .Earing(123000);
        WriteLine(personn);
        #endregion


        #region CodeBuilderPractice
        var cb = new CodeBuilder("Person")
            .AddField("Name", "string")
            .AddField("Age", "int");
        WriteLine(cb);
        #endregion

        #region PointExample
        var px = PointExampleForApi.NewCartesianPoint(1.0, Math.PI / 2);
        WriteLine(px);
        #endregion

        #region Object Tracking and Bulk Replacement
        var factory = new TrackingThemeFactory();
        var theme1 = factory.CreateTheme(false);
        var theme2 = factory.CreateTheme(true);
        WriteLine(factory.Info);

        var factory2 = new ReplaceableThemeFactory();
        var magicTheme = factory2.CreateTheme(true);
        WriteLine(magicTheme.Value.BgrColor);
        factory2.ReplaceTheme(false);
        WriteLine(magicTheme.Value.BgrColor);
        #endregion
    }
}