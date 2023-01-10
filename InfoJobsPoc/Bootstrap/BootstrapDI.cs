using InfoJobsPoc.Application.Interfaces.IQuery;
using InfoJobsPoc.Application.Querys;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Core.Interfaces.IService;
using InfoJobsPoc.Core.ServiceUseCases.CandidateUseCase;
using InfoJobsPoc.Core.ServiceUseCases.ExperienceUseCase;
using InfoJobsPoc.Infra.Contexts;
using InfoJobsPoc.Infra.QuerysInfra;
using InfoJobsPoc.Infra.RepositoryWrites;
using InfoJobsPoc.Web.Graphql;
using InfoJobsPoc.Web.Socket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfoJobsPoc.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection AddBootstrapDemo(this IServiceCollection Services, IConfiguration c)
        {
            Services.AddDbContext<PocContextQuery>(o => o.UseSqlServer(c.GetConnectionString("localdb")));
            Services.AddDbContext<PocContextWritte>(o => o.UseSqlServer(c.GetConnectionString("localdb")));

            Services.AddTransient(typeof(IRepositoryWriteBase<>), typeof(RepositoryWriteBase<>));
            Services.AddTransient(typeof(IQueryInfraBase<>), typeof(QueryInfraBase<>));

            Services.AddScoped(typeof(IQueryApplication<>), typeof(QueryApplication<>));

            Services.AddScoped<IServiceBase<Candidate>, ServiceCandidate>();
            Services.AddScoped<IServiceBase<Experience>, ServiceExperience>();
            //
            Services.AddMediatR(Assembly.GetExecutingAssembly());

            Services
                       .AddGraphQLServer()
                       .AddMutationType<MutationGraphql>()
                       .AddQueryType<QueryGraphql>()
                       .AddFiltering()
                       .AddProjections();
            Services.AddSignalR();

            return Services;
        }
        public static void MapBootstrapDemo(this WebApplication app)
        {
            app.MapGraphQL();
            app.MapHub<SignalRHub>("/hub");
        }
    }
}