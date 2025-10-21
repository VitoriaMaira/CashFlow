using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson> //tipo de validator que será usado para validar os dados do usuário
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITULO_OBRIGATORIO); /*"Crie uma regra para a propriedade Title do objeto expense,
     exigindo que ela não esteja vazia. Caso esteja, mostre a mensagem 'O título é obrigatório'."*/

        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.VALOR_MAIOR_QUE_ZERO);

        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_NAO_FUTURA);

        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.TIPO_PAGAMENTO_INVALIDO);
    }
}
