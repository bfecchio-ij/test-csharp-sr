using InfoJobs.KnowledgeTest.Data.Infra.IoC.Modulos;
using Microsoft.Extensions.DependencyInjection;

namespace InfoJobs.KnowledgeTest.Data.Infra.IoC.App_Start
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Curriculum.Initializer(services);
        }        
    }
}