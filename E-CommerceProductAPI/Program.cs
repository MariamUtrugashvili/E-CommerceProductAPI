using E_CommerceProduct.Persistance.Context;
using E_CommerceProductAPI.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using E_CommerceProductAPI.Infrastructure.Extensions.MiddleWare;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Serilog

builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

#endregion



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.ConfigureServices();

#region AddDbContext

builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionString.DefaultConnection))));

builder.Services.AddScoped<DbContext, ProductDbContext>();

#endregion

#region FluentValidation

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

#endregion

var app = builder.Build();

app.UseGlobalExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRequestResponseMiddleware();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    dbContext.Database.Migrate();
}


try
{
    Log.Information("Starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Terminated");
}
finally
{
    Log.CloseAndFlush();
}
