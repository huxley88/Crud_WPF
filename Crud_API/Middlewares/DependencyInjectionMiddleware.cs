using Crud_WPF.Business;
using Crud_WPF.Business.Interfaces;
using Crud_WPF.Factories;
using Crud_WPF.Factories.Interfaces;
using Crud_WPF.Interfaces;
using Crud_WPF.RabbitMQConsumer;
using Crud_WPF.RabbitMQSender;
using Crud_WPF.Repository;
using Crud_WPF.Repository.Interfaces;
using Crud_WPF.Services;
using Crud_WPF.Services.Interfaces;
using Crud_WPF.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crud_API.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configurações

            services.AddSingleton(configuration);

            #endregion

            #region Conexões

            services.AddSingleton<IDapperConnectionFactory, DapperConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Middlewares

            services.AddCors();

            #endregion

            #region Cliente

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteBusiness, ClienteBusiness>();
            services.AddScoped<IClienteServices, ClienteServices>();

            #endregion

            #region RabbitMQ

            services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();
            services.AddScoped<IRabbitMQSender, RabbitMQSender>();

            #endregion
        }
    }
}
