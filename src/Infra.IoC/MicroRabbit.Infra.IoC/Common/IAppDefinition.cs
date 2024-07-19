using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC.Common
{
    public interface IAppDefinition
    {

        void ConfigureServices(IServiceCollection services);
    }
}
