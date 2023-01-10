using InfoJobsPoc.Application.CandidateCommands.CandidateCommandHandle;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.IHandle;
using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IService;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandHandle
{
    public class AddExperienceCommandHandle : IHandleApp<AddExperienceRequest, ExperienceResponse>, IMediatorHandlers<AddExperienceRequest, ExperienceResponse>
    {
        private ILogger<AddExperienceCommandHandle> Logger;
        private readonly IServiceBase<Experience> service;
        public AddExperienceCommandHandle(ILogger<AddExperienceCommandHandle> Logger, IServiceBase<Experience> service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.Logger = Logger;
        }

        public Task<ExperienceResponse> Handle(AddExperienceRequest request, CancellationToken cancellationToken)
        {
            var jsonOpt = new JsonSerializerOptions { WriteIndented = true };
            Logger.LogDebug("Start Handle: " + JsonSerializer.Serialize(request, jsonOpt));

            Experience exp = new Experience()
            {
                BeginDate = request.BeginDate,
                IdCandidate = request.IdCandidate,
                EndDate = request.EndDate,
                Company = request.Company,
                Description = request.Description,
                Salary = request.Salary,
                Job = request.Job
            };      
            var result = service.Add(exp);
            var response = new ExperienceResponse()
            {

                Data = ExperienceResponse.parse(result?.Data),
                KeyPattern = result?.KeyPattern ?? "",
                Messages = result?.Messages ?? new List<Notify>() { new Notify(StatusEnum.Error, typeof(ExperienceResponse).Name, "unlisted error") },
            };
            Logger.LogDebug("Response: " + JsonSerializer.Serialize(response, jsonOpt));

            return Task.FromResult(response);
        }
    }
}
