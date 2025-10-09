using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApi.Application.Interfaces.Security;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;
using StockApi.Infrastructure.Repository;
using StockApi.Infrastructure.Security;

namespace StockApi.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("DefaultConnection");

            // Đăng ký DbContext (SQL Server)
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(cs, b => b
                    .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    .MigrationsHistoryTable("__EFMigrationsHistory_SqlServer")));

            // Đăng ký repository
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();



            return services;
        }
    }
}