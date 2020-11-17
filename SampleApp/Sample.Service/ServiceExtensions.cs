using Microsoft.Extensions.DependencyInjection;
using Sample.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Sample.Service.Services;

namespace Sample.Service
{
    public static class ServiceExtensions
    {
        public static void AddServiceInstances(this IServiceCollection services)
        {
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IMedicineOrderService, MedicineOrderService>();
        }
    }
}
