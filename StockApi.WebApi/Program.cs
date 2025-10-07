using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StockApi.Application.Features.Stocks.Queries.GetStocks;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;
using StockApi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetStockQueryHandler).Assembly);
});
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

