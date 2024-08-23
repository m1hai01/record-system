using Domain.Abstractions;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class ConfigureRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IIndividualRepository, IndividualRepository>();

            return services;
        }
    }
}
