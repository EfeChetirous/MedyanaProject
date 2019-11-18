using Medyana.Data;
using Medyana.Service.Interfaces;
using Medyana.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IClinicService, ClinicService>();
            serviceCollection.AddScoped<IEquipmentService, EquipmentService>();
            serviceCollection.AddScoped<ILogService, LogService>();            
        }
    }
}
