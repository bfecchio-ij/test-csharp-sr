using InfoJobs.KnowledgeTest.Application.Curriculum.Service;
using InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using InfoJobs.KnowledgeTest.Infra.Data.Repositories.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Infra.Data.Repositories.Curriculum.Queryes;
using Microsoft.Extensions.DependencyInjection;

namespace InfoJobs.KnowledgeTest.Data.Infra.IoC.Modulos
{
    public static class Curriculum
    {
        public static void Initializer(IServiceCollection services)
        {
            AddApplication(services);
            AddServices(services);
            AddRepositories(services);
            AddContexts(services);
        }

        private static void AddApplication(IServiceCollection services)
        {
            services.AddScoped<ICandidateApp, CandidateApp>();
            services.AddScoped<ICandidateExperienceApp, CandidateExperienceApp>();
        }

        private static void AddServices(IServiceCollection services)
        {

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICandidateCommandRepository, CandidateCommandRepository>();
            services.AddScoped<ICandidateExperienceCommandRepository, CandidateExperienceCommandRepository>();
            services.AddScoped<ICandidateQueryRepository, CandidateQueryRepository>();
            services.AddScoped<ICandidateExperienceQueryRepository, CandidateExperienceQueryRepository>();
        }

        private static void AddContexts(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<CurriculumContext>, UnitOfWork<CurriculumContext>>();
        }
    }
}