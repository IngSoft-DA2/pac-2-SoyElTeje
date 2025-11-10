using BusinessLogic;
using IBusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IImporterLogic, ImporterLogic>();
        }
    }
}
