using InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.IHandle;
using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers;
using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IService;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandHandle
{

    public class AddCandidateHandle : IHandleApp<AddCandidateRequest, CandidateReponse>, IMediatorHandlers<AddCandidateRequest, CandidateReponse>
    {
        private readonly IServiceBase<Candidate> service;
        private readonly ILogger<AddCandidateHandle> Logger;
        public AddCandidateHandle(ILogger<AddCandidateHandle> Logger, IServiceBase<Candidate> service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.Logger = Logger;  
        }

        public Task<CandidateReponse> Handle(AddCandidateRequest request, CancellationToken cancellationToken)
        {
            var jsonOpt = new JsonSerializerOptions { WriteIndented = true };
            Logger.LogDebug("Start Handle: "+JsonSerializer.Serialize(request, jsonOpt));
                     
            Candidate candidate = new Candidate(request.Name, request.Surname, request.Birthdate, request.Email);            
          
            var result = service.Add(candidate);
            
            var response = new CandidateReponse()
            {

                Data = CandidateReponse.parse(result?.Data, candidate),
                KeyPattern = result?.KeyPattern ?? "",
                Messages = result?.Messages ?? new List<Notify>() { new Notify(StatusEnum.Error, typeof(AddCandidateHandle).Name, "unlisted error") },

            };
            Logger.LogDebug("Response: "+JsonSerializer.Serialize(response, jsonOpt));

            return Task.FromResult(response);
        }

    }
}
