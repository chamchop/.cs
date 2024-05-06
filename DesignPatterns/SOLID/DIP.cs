namespace SOLID.SOLID
{
    public class DIP
    {
        public enum Relationship
        {
            Parent,
            Child,
            Sibling
        }

        public class Person
        {
            public string Name { get; set; }
        }

        public interface IRelationshipSearch
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
        }

        public class Relationships : IRelationshipSearch
        {
            private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }

            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(relations => relations.Item3);
            }
        }

        public class Search
        {
            public Search(IRelationshipSearch search)
            {
                foreach (var item in search.FindAllChildrenOf("John"))
                {
                    Console.Write(item.Name);
                }
            }

            public static void Exe()
            {
                var parent = new Person() { Name = "John" };
                var child1 = new Person() { Name = "Jack" };
                var child2 = new Person() { Name = "Jill" };

                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(parent, child2);

                new Search(relationships);
            }
        }
    }
}
