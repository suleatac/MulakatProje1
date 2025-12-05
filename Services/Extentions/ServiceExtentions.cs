using App.Repositories;
using App.Repositories.Products;
using App.Services.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            // Register other repositories if needed

            //DbContextin yaşam döngüsünü Scoped yapıyoruz ki her istek için yeni bir DbContext örneği oluşturulsun.
            services.AddScoped<IProductService, ProductService>();


            return services;
        }
    }
}

