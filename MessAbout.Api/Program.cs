using MediatR;
using MessAbout.Api.Contracts;
using MessAbout.Api.Infrastructure;
using MessAbout.Api.Infrastructure.Extensions;
using MessAbout.Api.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.MapPost("/api/products", async (CreateProductRequest request, ISender sender) =>
{
    var command = new CreateProduct.Command
    {
        Name = request.Name
    };

    var productId = await sender.Send(command);

    return Results.Ok(productId);
});

app.UseHttpsRedirection();

app.Run();

public partial class Program { }