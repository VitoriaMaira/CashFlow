namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    //public required string ErrorMessage { get; set; } = string.Empty; usar required ou ctor
    public List<string> ErrorMessages { get; set; }// para armazenar as mensagens de erro que serão retornadas para o usuário

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }
}
/*codigo para retornar uma mensagem de erro personalizada para o usuário, caso ele envie dados inválidos em formato
Json*/