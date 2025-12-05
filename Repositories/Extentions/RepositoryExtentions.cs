using App.Repositories.Products;
using App.Repositories.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.Extentions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var connectionStrings=configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction => {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });
            });
            // Register other repositories if needed

            //DbContextin yaşam döngüsünü Scoped yapıyoruz ki her istek için yeni bir DbContext örneği oluşturulsun.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitofWork, UnitofWork.UnitofWork>();

            return services;
        }
    }
}
