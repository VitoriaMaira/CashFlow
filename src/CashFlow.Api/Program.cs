
using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;


namespace CashFlow.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

            //Dependency Injection
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseMiddleware<CultureMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
