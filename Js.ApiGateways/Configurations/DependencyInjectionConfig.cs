using System;
using Js.ApiGateways.Services;
using JS.WebAPI.Core.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Js.ApiGateways.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            //  services.AddHttpClient<ICatalogoService, CatalogoService>()
            //     .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //   .AllowSelfSignedCertificate()
            //   .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //   .AddTransientHttpErrorPolicy(
            //       p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            // services.AddHttpClient<ICarrinhoService, CarrinhoService>()
            //     .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AllowSelfSignedCertificate()
            //    .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //    .AddTransientHttpErrorPolicy(
            //        p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddHttpClient<IContaService, ContaServices>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IClientesService, ClientesServices>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            //services.AddHttpClient<IClienteService, ClienteService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AllowSelfSignedCertificate()
            //    .AddPolicyHandler(PollyExtensions.EsperarTentar())
            //    .AddTransientHttpErrorPolicy(
            //        p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
        }
    }
}