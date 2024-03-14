using BasketAPI.Core.Databases;
using BasketAPI.Core.Databases.InMemory;
using BasketAPI.Core.IRepositories;
using BasketAPI.Core.Repositories;
using BasketAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(connection);
});

builder.Services.AddSingleton<BasketMemory>();
builder.Services.AddSingleton<BasketItemMemory>();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketItemRepository, BasketItemRepository>();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.LoadDataToMemory<BasketMemory, ApplicationDbContext>((data, context) =>
{
    new BasketMemorySeedAsync().SeedAsync(data,context).Wait();
});

app.LoadDataToMemory<BasketItemMemory, ApplicationDbContext>((data, context) =>
{
    new BasketItemMemorySeedAsync().SeedAsync(data,context).Wait();
});

app.Run();
