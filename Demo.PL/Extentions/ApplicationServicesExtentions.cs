using Demo.BLL.Interfaces;
using Demo.BLL.Reopsitories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.PL.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddAplicationServices (this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
