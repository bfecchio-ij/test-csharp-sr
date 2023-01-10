using InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.IHandle;
using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Interfaces.IService;
using System.Text.Json;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandHandle
{
    public class UpdateCandidateHandle : IHandleApp<UpdateCandidateRequest, CandidateReponse>, IMediatorHandlers<UpdateCandidateRequest, CandidateReponse>
    {
        private readonly IServiceBase<Experience> serviceExp;

        private readonly ILogger<RemoveCandidateHandle> Logger;
        private readonly IServiceBase<Candidate> service;
        public UpdateCandidateHandle(ILogger<RemoveCandidateHandle> Logger, IServiceBase<Candidate> service, IServiceBase<Experience> serviceExp)
        {
            this.serviceExp = serviceExp ?? throw new ArgumentNullException(nameof(serviceExp));
            this.service = service;
            this.Logger = Logger;
        }

        public Task<CandidateReponse> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {
            Logger.LogDebug("Start Handle: " + JsonSerializer.Serialize(request));
            var candidate = new Candidate(request.Name, request.Surname, request.Birthdate, request.Email);            
    
            var result = service.Update(candidate);
            var response = new CandidateReponse()
            {
                Data = CandidateReponse.parse(result?.Data, candidate),
                KeyPattern = result?.KeyPattern ?? "",
                Messages = result.Messages,
            };
            if (request.experiences?.Count() > 0)
            {
                request.experiences.Select(x => new Experience
                {
                    Id = x.Id,
                    BeginDate = x.BeginDate,
                    EndDate = x.EndDate,
                    IdCandidate = request.Id,
                    Company = x.Company,
                    Description = x.Description,
                    Job = x.Job,
                    Salary = x.Salary,
                    ModifyDate = DateTime.Now,
                    InsertDate = DateTime.Now
                }).ToList()
                .ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                      response.Messages.AddRange(serviceExp.Add(x).Messages);
                    }
                    else
                    {
                        response.Messages.AddRange(serviceExp.Update(x).Messages);
                    }
                });
            }
           
            Logger.LogDebug("Response: " + JsonSerializer.Serialize(response));
            return Task.FromResult(response);
        }
    }
}
