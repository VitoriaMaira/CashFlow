using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;database=cashflowdb;user=root;password=.Maira123";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 43)); // Adjust version as needed

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
