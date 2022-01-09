using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Config
{
    public static class ConfigApplication
    {
        public static void ConfigureApplication(this IServiceCollection service)
        {
            //service.AddTransient<IPostoService, PostoService>();
        }
    }
}
