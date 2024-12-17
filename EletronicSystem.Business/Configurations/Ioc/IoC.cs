using EletronicSystem.Data.Repository;
using EletronicSystem.Business.Services;
using EletronicSystem.Business.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using EletronicSystem.Data.Repository.Interfaces;

namespace EletronicSystem.Business.Configurations.Ioc
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService,ClienteService>();
            services.AddScoped<IProdutoService,ProdutoService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
