using AutoMapper;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.DAL
{
    public static class DALExtension
    {
        public static IServiceCollection ConfigureDAL(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
        public static IServiceCollection ConfigureBLL(this IServiceCollection services)
        {
            services.AddTransient<ICasinoService, CasinoService>();
            return services;
        }
    }
}