global using FastEndpoints;
global using FluentValidation;
global using Microsoft.EntityFrameworkCore;
using backend_challenge.context;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Challenge"));

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "BNP backend Challenge";
        s.Description = "This service has been developed to test the ability of backend developer candidates";
        s.Version = "v1";
    };
});

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

if (builder.Environment.IsStaging() || builder.Environment.IsDevelopment())
    app.UseSwaggerGen();

app.Run();