using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Order.Pipeline;
using Order.Repository;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(err =>
{
    err.Run(async c =>
    {
        var error = c.Features.Get<IExceptionHandlerFeature>();

        await JsonSerializer.SerializeAsync(c.Response.Body, error.Error.Message);
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
