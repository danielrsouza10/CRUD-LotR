using Infra;
using Servico;
using Cod3rsGrowth.Web.ExceptionHandler;
using Microsoft.Extensions.FileProviders;

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

var comando = args.FirstOrDefault();
var connectionString = comando is "--teste" ? Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING_TESTE") : Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");


ModuloDeInjecaoInfra.BindServices(builder.Services, connectionString);
ModuloDeInjecaoServico.BindServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "wwwroot", "webapp")),
    EnableDirectoryBrowsing = true
});

app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
