using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

//Define as operações que podem ser realizadas no repositório de despesas
public interface IExpensesRepository
{
    Task Add(Expense expense);
}
