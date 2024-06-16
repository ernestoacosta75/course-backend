using AutoMapper.Execution;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Films.Core.Application.Services.Gender;
using ProxyGenerator = Castle.DynamicProxy.ProxyGenerator;

namespace Films.Application.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGenderService, GenderService>();
        }

        public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        {
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();

                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }
    }
}
