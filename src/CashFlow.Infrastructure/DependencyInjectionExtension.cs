using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }

}
