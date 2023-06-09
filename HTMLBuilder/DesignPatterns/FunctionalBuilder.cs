﻿namespace DesignPatternBuilder.DesignPatterns
{
    #region Model
    public class Person
    {
        public string Name, Position;
    }
    #endregion

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private List<Func<Person, Person>> actions => new List<Func<Person, Person>>();
        public TSelf Do(Action<Person> action) => AddAction(action);
        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string positin) => builder.Do(p => p.Position = positin);
    }
    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }
}