using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next; //Permite que deixe o fluxo de requisições passar para o próximo middleware na cadeia de execução.

    public CultureMiddleware(RequestDelegate next) // construtor que recebe um RequestDelegate como parâmetro, que é o próximo middleware na cadeia de execução
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context) // Método Invoke que é chamado quando o middleware é executado. Ele recebe um HttpContext como parâmetro, que contém informações sobre a solicitação HTTP atual.
    {

        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("pt-BR");

        if (string.IsNullOrWhiteSpace(requestedCulture) == false
            && supportedLanguages.Exists(language => language.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
