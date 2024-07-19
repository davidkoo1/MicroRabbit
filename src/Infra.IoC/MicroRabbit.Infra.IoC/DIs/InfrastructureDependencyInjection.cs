using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Infrastructure.Persistance;
using MicroRabbit.Banking.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC.DIs
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BankingDbConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
