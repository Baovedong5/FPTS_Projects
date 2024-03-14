using Customer_OrderAPI.Core.Databases;
using Customer_OrderAPI.Core.Databases.InMemory;
using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.Core.Repositories;
using Customer_OrderAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(connection);
});

builder.Services.AddSingleton<CustomerMemory>();
builder.Services.AddSingleton<OrderMemory>();
builder.Services.AddSingleton<OrderItemMemory>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

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

app.LoadDataToMemory<CustomerMemory, ApplicationDbContext>((data, context) =>
{
    new CustomerMemorySeedAsync().SeedAsync(data, context).Wait();
});

app.LoadDataToMemory<OrderMemory, ApplicationDbContext>((data, context) =>
{
    new OrderMemorySeedAsync().SeedAsync(data, context).Wait();
});

app.LoadDataToMemory<OrderItemMemory, ApplicationDbContext>((data, context) =>
{
    new OrderItemMemorySeedAsync().SeedAsync(data, context).Wait();
});

app.Run();
