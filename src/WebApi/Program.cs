using Application;
using Infrastructure;
using Presentation;
using Serilog;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Host
    .UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.Migrate();
app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapTruckEndpoints();

app.Run();
