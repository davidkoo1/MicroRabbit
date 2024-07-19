using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC.Common
{
    public abstract class AppDefinition : IAppDefinition
    {
        public virtual void ConfigureServices(IServiceCollection services) { }
    }
}
