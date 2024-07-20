using MediatR;
using MicroRabbit.Banking.Application.Commands;
using MicroRabbit.Banking.Application.Commands.CreateTransfer;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;



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

            //Application Banking Services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHeandler>();

            //Application Transfer Services
            services.AddTransient<ITransferService, TransferService>();

            //Data Transfer Services
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<TransferDbContext>();



            return services;

        }

    }
}
