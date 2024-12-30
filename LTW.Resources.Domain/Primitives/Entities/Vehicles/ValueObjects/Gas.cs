using LavanderTyperWeb.Core.DomainObjects;
using LTW.Resources.Domain.Primitives.Common.ValueObjects;

namespace LTW.Resources.Domain.Primitives.Entities.Vehicles.ValueObjects
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
