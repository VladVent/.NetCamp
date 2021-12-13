using BlackJack.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection ConfigureBLL(this IServiceCollection services)
        {
            services.AddTransient<ICasinoService, CasinoService>();
            return services;
        }
    }
}