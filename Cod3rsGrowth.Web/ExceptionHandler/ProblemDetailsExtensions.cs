using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Cod3rsGrowth.Web.ExceptionHandler
{
    public static class ProblemDetailsExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is ValidationException validationRequestException)
                        {
                            problemDetails.Title = "Ocorreram um ou mais erros de validação";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = validationRequestException.StackTrace;
                            problemDetails.Extensions["Erros"] = validationRequestException.Errors
                            .GroupBy(error => error.PropertyName)
                            .ToDictionary(group => group.Key, group => group.First().ErrorMessage);
                        }
                        else if (exception is SqlException sqlRequestException)
                        {
                            problemDetails.Title = "O Id da raça não existe";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = sqlRequestException.StackTrace;
                            problemDetails.Extensions["Erros"] = sqlRequestException.Message;
                        }
                        else if (exception is Exception requestException)
                        {
                            problemDetails.Title = "Um erro inesperado ocorreu";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = requestException.StackTrace;
                            problemDetails.Extensions["Erros"] = requestException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");
                            problemDetails.Title = "Erro inesperado";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.StackTrace;
                        }
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(problemDetails, SerializerSettings.JsonSerializerSettings);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
        public static IServiceCollection ConfigureProblemDetailsModelState(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Title = "Requisição com dados de entrada inválidos ou insuficientes",
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Uma ou mais propriedades não foram preenchidas ou são insuficientes"
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }
    }
}

