namespace CashFlow.Exception.ExceptionBase;

public class ErrorOnValidationException : CashFlowException
{
    public List<string> Errors { get; set; } // para armazenar os erros de validação que ocorreram durante a execução do sistema

    public ErrorOnValidationException(List<string> ErrorMessages)
    {
        Errors = ErrorMessages;

    }// para inicializar a lista de erros de validação com os erros que ocorreram durante a execução do sistema
}
