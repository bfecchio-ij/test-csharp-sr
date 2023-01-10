using InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Querys;
using InfoJobsPoc.Core.Interfaces.IRepository;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace InfoJobsPoc.Web.Socket
{

    public class SignalRHub : Hub
    {
        private readonly IMediator mediator;
        private readonly IQueryInfraBase<CandidateModelQuery> queryCandidate;
        public SignalRHub(IMediator mediator, IQueryInfraBase<CandidateModelQuery> queryCandidate)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queryCandidate = queryCandidate ?? throw new ArgumentNullException();
        }
        public async Task<List<CandidateModelQuery>> Get() => await queryCandidate.QueryList().Select(x => NormalizeForRest(x)).ToListAsync();
        public async Task<List<CandidateModelQuery>> GetId(int Id) => await queryCandidate.QueryList(x => x.Id == Id, NormalizeForRest).ToListAsync();
        public async Task<List<CandidateModelQuery>> GetEmail(string Email) => await queryCandidate.QueryList(x => x.Email.Trim() == Email.Trim(), NormalizeForRest).ToListAsync();
        public Task<CandidateReponse> Create(AddCandidateRequest request)
        {
            return mediator.Send(request);
        }
        public Task<CandidateReponse> Update(UpdateCandidateRequest request)
        {
            return mediator.Send(request);
        }
        public Task<CandidateReponse> Delete(RemoveCandidateRequest request)
        {
            return mediator.Send(request);
        }
        public Task<string> Ping()
        {
            return Task.FromResult("pong");
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
