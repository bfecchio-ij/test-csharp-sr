using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.IHandle;
using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Interfaces.IService;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandHandle
{
    public class UpdateExperienceCommandHandle : IHandleApp<UpdateExperienceRequest, ExperienceResponse>, IMediatorHandlers<UpdateExperienceRequest, ExperienceResponse>
    {
        private ILogger<UpdateExperienceCommandHandle> Logger;
        private readonly IServiceBase<Experience> service;

        public UpdateExperienceCommandHandle(ILogger<UpdateExperienceCommandHandle> logger, IServiceBase<Experience> service)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Task<ExperienceResponse> Handle(UpdateExperienceRequest request, CancellationToken cancellationToken)
        {
            Logger.LogDebug("Start Handle: " + JsonSerializer.Serialize(request));
            var candidate = new Experience()
            {
                Id = request.Id,
                Company = request.Company,
                Job = request.Job,
                Description = request.Description,
                Salary = request.Salary,
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
            };
            var result = service.Update(candidate);
            var response = new ExperienceResponse()
            {
                Data = ExperienceResponse.parse(result?.Data),
                KeyPattern = result?.KeyPattern ?? "",
                Messages = result.Messages,
            };
            Logger.LogDebug("Response: " + JsonSerializer.Serialize(response));
            return Task.FromResult(response);
        }
    }
}
