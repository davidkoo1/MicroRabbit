using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
//using MicroRabbit.Transfer.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Application Services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            //Domain Banking Commands
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHeandler>();

            ////Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<TransferDbContext>();



            return services;

        }

    }
}
