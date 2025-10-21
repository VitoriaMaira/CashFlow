using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestsUtilies.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
             .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
             .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
             .RuleFor(r => r.Date, faker => faker.Date.Past())
             .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
             .RuleFor(R => R.Amount, faker => faker.Random.Decimal(min: 1, max: 999));
    }
}
