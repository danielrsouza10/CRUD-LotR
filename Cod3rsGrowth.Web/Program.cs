using Infra;
using Servico;
using Cod3rsGrowth.Web.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureProblemDetailsModelState();


ModuloDeInjecaoInfra.BindServices(builder.Services);
ModuloDeInjecaoServico.BindServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
