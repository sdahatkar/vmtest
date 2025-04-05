using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTest.Domain.Sales;
using VMTest.Infrastructure.Data;
using VMTest.Infrastructure.Data.Csv;
using VMTest.Infrastructure.Data.Csv.Mappers;
using VMTest.Infrastructure.Sales;

namespace VMTest.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataFiles>(configuration.GetSection("DataFiles"));

            services.AddScoped<ClassMap<Sale>, SaleMap>();

            services.AddScoped(typeof(ICsvService<>), typeof(CsvService<>));

            services.AddScoped<ISaleRepository, SaleRepository>();

            return services;
        }
    }
}
