using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.IQuery;
using InfoJobsPoc.Application.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoJobsPoc.Web.Rest
{
    public class ExperienceController : ControllerBase
    {
        private readonly IQueryApplication<ExperienceModelQuery> queryExperience;

        public ExperienceController(IQueryApplication<ExperienceModelQuery> queryExperience)
        {
            this.queryExperience = queryExperience ?? throw new ArgumentNullException(nameof(queryExperience));
        }

        [HttpGet("/api/Experiences")]
        public async Task<List<ExperienceModelQuery>> Get() => await queryExperience.QueryList().Select(x => NormalizeForRest(x)).ToListAsync();

        [HttpGet("/api/Experiences/id/{id}")]
        public async Task<List<ExperienceModelQuery>> GetId(int Id) => await queryExperience.QueryList(x => x.Id == Id, NormalizeForRest).ToListAsync();

        [HttpPost("/api/Experiences")]
        public Task<ExperienceResponse> Create([FromServices] IMediator mediator, AddExperienceRequest request)
        {
            return mediator.Send(request);
        }

        [HttpPut("/api/Experiences")]
        public Task<ExperienceResponse> Update([FromServices] IMediator mediator, UpdateExperienceRequest request)
        {
            return mediator.Send(request);
        }

        [HttpDelete("/api/Experiences")]
        public Task<ExperienceResponse> Delete([FromServices] IMediator mediator, RemoveExperienceRequest request)
        {
            return mediator.Send(request);
        }
        public ExperienceModelQuery NormalizeForRest(ExperienceModelQuery experience) => new ExperienceModelQuery
        {
            Job = experience.Job,
            Id = experience.Id,
            BeginDate = experience.BeginDate,
            Candidate = null,
            Company = experience.Company,
            Description = experience.Description,
            EndDate = experience.EndDate,
            IdCandidate = experience.IdCandidate,
            InsertDate = experience.InsertDate,
            ModifyDate = experience.ModifyDate,
            Salary = experience.Salary
        };
    }
}
