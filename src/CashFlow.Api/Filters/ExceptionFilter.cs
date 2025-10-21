using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter //interface que define um filtro de exceção que pode ser aplicado a um controlador ou ação
{
    public void OnException(ExceptionContext context) // o que acontece quando uma exeção é lançada
    {
        if (context.Exception is CashFlowException)// verifica se a exceção é do tipo CashFlowException, que é uma exceção personalizada para o sistema CashFlow
        {
            HandleProjectException(context); //chama o método HandleProjectException, que trata as exceções específicas do projeto, como ArgumentException e ErrorOnValidationException
        }
        else
        {
            ThrowUnknowError(context); //chama o método ThrowUnknowError, que define o código de status HTTP 500 (Erro Interno do Servidor) e retorna uma mensagem de erro genérica em formato JSON

        }

    }

    private void HandleProjectException(ExceptionContext context) // método que trata as exceções específicas do projeto, ex.: ArgumentException e ErrorOnValidationException
    {
        if (context.Exception is ErrorOnValidationException)// verifica se a exceção é do tipo ErrorOnValidationException, que é uma exceção personalizada para erros de validação
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors); // para retornar uma mensagem de erro personalizada para o usuário, caso ele envie dados inválidos em formato Json

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest; //define o código de status HTTP 500 (Erro Interno do Servidor)
            context.Result = new BadRequestObjectResult(errorResponse); //define o resultado da resposta HTTP como um objeto que contém a mensagem de erro

        }

        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message); //para retornar uma mensagem de erro personalizada para o usuário, caso ele envie dados inválidos em formato Json

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);

        }

    }

    private void ThrowUnknowError(ExceptionContext context)// método que define o código de status HTTP 500 (Erro Interno do Servidor) e retorna uma mensagem de erro genérica em formato JSON
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError; //define o código de status HTTP 500 (Erro Interno do Servidor)
        context.Result = new ObjectResult(errorResponse); //define o resultado da resposta HTTP como um objeto que contém a mensagem de erro


    }

}
