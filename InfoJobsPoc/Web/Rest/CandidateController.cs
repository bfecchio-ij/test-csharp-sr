using InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.IQuery;
using InfoJobsPoc.Application.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoJobsPoc.Web.Rest
{
    [Route("/api/candidates")]
    public class CandidateController : ControllerBase
    {
        private readonly IQueryApplication<CandidateModelQuery> queryCandidate;

        public CandidateController(IQueryApplication<CandidateModelQuery> queryCandidate)
        {
            this.queryCandidate = queryCandidate ?? throw new ArgumentNullException(nameof(queryCandidate));
        }

        [HttpGet("/api/candidates")]
        public async Task<List<CandidateModelQuery>> Get() => await queryCandidate.QueryList().Select(x => NormalizeForRest(x)).ToListAsync();

        [HttpGet("/api/candidates/id/{id}")]
        public async Task<List<CandidateModelQuery>> GetId(int Id) => await queryCandidate.QueryList(x => x.Id == Id, NormalizeForRest).ToListAsync();

        [HttpGet("/api/candidates/email/{email}")]
        public async Task<List<CandidateModelQuery>> GetEmail(string Email) => await queryCandidate.QueryList(x => x.Email.Trim() == Email.Trim(), NormalizeForRest).ToListAsync();

        [HttpPost("/api/candidates")]
        public Task<CandidateReponse> Create([FromServices] IMediator mediator, AddCandidateRequest request)
        {
            return mediator.Send(request);
        }

        [HttpPut("/api/candidates")]
        public Task<CandidateReponse> Update([FromServices] IMediator mediator, UpdateCandidateRequest request)
        {
            return mediator.Send(request);
        }

        [HttpDelete("/api/candidates")]
        public Task<CandidateReponse> Delete([FromServices] IMediator mediator, RemoveCandidateRequest request)
        {
            return mediator.Send(request);
        }
        public CandidateModelQuery NormalizeForRest(CandidateModelQuery candidate) => new CandidateModelQuery
        {
            Name = candidate.Name,
            Surname = candidate.Surname,
            Email = candidate.Email,
            Birthdate = candidate.Birthdate,
            Experiences = candidate.Experiences.Select(e => new ExperienceModelQuery
            {
                BeginDate = e.BeginDate,
                EndDate = e.EndDate,
                Company = e.Company,
                Description = e.Description,
                Job = e.Job,
                Salary = e.Salary,
                Id = e.Id,
                IdCandidate = e.IdCandidate,
                InsertDate = e.InsertDate,
                ModifyDate = e.ModifyDate
            }).ToList(),
        };
    }

}
