using FunRace.Core.DomainObjects;

namespace Gympass.Domain.Aggregate
{
    public class Driver : Entity
    {
        public string Name { get; private set; }

        private Driver(long id, string name)
        {
            ValidationAssertionConcern.IsNull(name, "Name can't be empty or null");

            Id = id;
            Name = name;
        }

        public static Driver Create(long id, string name)
        {
            return new Driver(id, name);
        }

        public override bool IsValid()
        {
            return Id > 0 && !string.IsNullOrEmpty(Name);
        }
    }
}
