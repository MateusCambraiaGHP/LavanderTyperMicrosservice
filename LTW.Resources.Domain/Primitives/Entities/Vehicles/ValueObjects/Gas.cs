using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Common.ValueObjects;

namespace LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.ValueObjects
{
    public class Gas : ValueObject
    {
        public double Price { get; set; }
        public DateOnly Date { get; set; }

        private Gas() { }

        public Gas(double price, DateOnly date)
        {
            Price = price;
            Date = date;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { Price, Date };
        }
    }
}
