using ProductAPI.Core.Database;
using ProductAPI.Core.Database.InMemory;
using ProductAPI.Core.IRepositories;
using ProductAPI.Core.Repositories;
using ProductAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOracle<ApplicationDbContext>(connection);

builder.Services.AddSingleton<ProductMemory>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

app.LoadDataToMemory<ProductMemory,ApplicationDbContext>((data, dbContext) =>
{
    new ProductMemorySeedAsync().SeedAsync(data, dbContext).Wait();
});

app.Run();
