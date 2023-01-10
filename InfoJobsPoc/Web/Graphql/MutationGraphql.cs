using InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest;
using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest;
using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using MediatR;

namespace InfoJobsPoc.Web.Graphql
{
    public class MutationGraphql
    {

        public async Task<CandidateReponse> AddCandidate([Service] IMediator mediator, AddCandidateRequest payload)
        {
            return await mediator.Send(payload);
        }

        public async Task<CandidateReponse> UpdateCandidate([Service] IMediator mediator, UpdateCandidateRequest payload)
        {
            return await mediator.Send(payload);
        }

        public async Task<CandidateReponse> RemoveCandididate([Service] IMediator mediator, RemoveCandidateRequest payload)
        {
            return await mediator.Send(payload);
        }

        public async Task<ExperienceResponse> AddExperience([Service] IMediator mediator, AddExperienceRequest payload)
        {
            return await mediator.Send(payload);
        }

        public async Task<ExperienceResponse> UpdateExperience([Service] IMediator mediator, UpdateExperienceRequest payload)
        {
            return await mediator.Send(payload);
        }

        public async Task<ExperienceResponse> RemoveExperience([Service] IMediator mediator, RemoveExperienceRequest payload)
        {
            return await mediator.Send(payload);
        }
    }
}
