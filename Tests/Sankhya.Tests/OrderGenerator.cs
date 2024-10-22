using Bogus;

namespace Sankhya.Tests
{
    public static class OrderGenerator
    {
        public static Order CreateFakeOrder()
        {
            var faker = new Faker<Order>()
                .RuleFor(o => o.OrderId, f => f.Random.Guid().ToString())
                .RuleFor(o => o.CustomerName, f => f.Person.FullName)
                .RuleFor(o => o.Amount, f => f.Finance.Amount());

            return faker.Generate();
        }
    }
}
