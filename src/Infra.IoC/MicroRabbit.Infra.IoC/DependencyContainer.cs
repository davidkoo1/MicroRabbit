using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Infrastructure.Persistance;
using MicroRabbit.Banking.Infrastructure.Repository;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Infra.IoC.DIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Application Services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            ////Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<BankingDbContext>();


            //Infra
            services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BankingDbConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;

        }

    }
}
