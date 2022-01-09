using Application.Common.Interfaces;
using Infra.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Persistence.Context;

namespace Infra.Config
{
    public static class ConfigInfra
    {
        public static void ConfigureInfra(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<EntityContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
                options.LogTo(Console.WriteLine);
            });
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
