using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.DAL.IRepositories;
using Sample.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DAL
{
   public static class RepositoryExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<AppDBContext>(context =>
            {
                context.UseSqlServer(connectionString);
            });
        }

        public static void AddRepositoryInstances(this IServiceCollection services)
        {
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineOrderRepository, MedicineOrderRepository>();
        }
    }
}
