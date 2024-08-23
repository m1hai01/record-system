using Application;
using Application.Configuration;
using Infrastructure;
using Infrastructure.Configuration;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddServices() // Adds service services (like your Service classes)
    .AddRepositories() // Adds repository services (like your Repository classes)
    .AddApplication() // Adds application services (like your Service classes)
    .AddInfrastructure(); // Adds infrastructure services (like your Repository classes)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map the endpoints from the Endpoints folder
app.MapEnterpriseEndpoints();
app.MapIndividualEndpoints();

app.Run();
