using InfoJobsPoc.Application.CandidateCommands.CandidateCommandHandle;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.IHandle;
using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IService;
using System.Text.Json;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandHandle
{
    public class RemoveExperienceCommandHandle : IHandleApp<RemoveExperienceRequest, ExperienceResponse>, IMediatorHandlers<RemoveExperienceRequest, ExperienceResponse>
    {
        private ILogger<RemoveExperienceCommandHandle> Logger;
        private readonly IServiceBase<Experience> service;

        public RemoveExperienceCommandHandle(ILogger<RemoveExperienceCommandHandle> logger, IServiceBase<Experience> service)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Task<ExperienceResponse> Handle(RemoveExperienceRequest request, CancellationToken cancellationToken)
        {
            var jsonOpt = new JsonSerializerOptions { WriteIndented = true };

            Logger.LogDebug("Start Handle: " + JsonSerializer.Serialize(request, jsonOpt));
            var result = service.Remove(request.Id);
            var response = new ExperienceResponse()
            {
                KeyPattern = result?.KeyPattern ?? "",
                Messages = result?.Messages ?? new List<Notify>() { new Notify(StatusEnum.Error, typeof(RemoveExperienceCommandHandle).Name, "unlisted error") },
            };
            Logger.LogDebug("Response: " + JsonSerializer.Serialize(response, jsonOpt));
            return Task.FromResult(response);
        }
    }
}
