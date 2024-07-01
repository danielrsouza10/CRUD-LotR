using Infra;
using Servico;
using Hellang.Middleware.ProblemDetails;
using Servico.CustomExceptions;
using Servico.CustomDetails;
using Microsoft.Data.SqlClient;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ModuloDeInjecaoInfra.BindServices(builder.Services);
ModuloDeInjecaoServico.BindServices(builder.Services);

builder.Services.AddProblemDetails(setup =>
{
    setup.IncludeExceptionDetails = (ctx, env) => builder.Environment.IsDevelopment()
                                  || builder.Environment.IsStaging();

    setup.Map<PersonagemCustomExceptions>(exception => new PersonagemCustomDetails
    {
        Title = exception.Title,
        Detail = exception.Detail,
        Status = StatusCodes.Status400BadRequest,
        Type = exception.Type,
        Instance = exception.Instance,
    });

    setup.Map<ValidationException>(exception => new ProblemDetails
    {
        Title = "Validation error",
        Detail = exception.Message,
        Status = StatusCodes.Status400BadRequest,
        Instance = "A instancia de validação",
    });

    setup.Map<SqlException>(exception => new ProblemDetails
    {
        Title = "Database error",
        Detail = exception.Message,
        Status = StatusCodes.Status500InternalServerError,
        Instance = "A instancia de erro no banco de dados",
    });

    setup.Map<Exception>(exception => new ProblemDetails
    {
        Title = "An unexpected error occurred",
        Detail = exception.Message,
        Status = StatusCodes.Status500InternalServerError,
        Instance = "A instancia de erro inesperado",
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
