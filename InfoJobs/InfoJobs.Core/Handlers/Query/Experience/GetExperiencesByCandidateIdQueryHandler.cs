using AutoMapper;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Query
{
    public class GetExperiencesByCandidateIdQuery : IRequest<IEnumerable<ExperienceDTO>>
    {
        public int CandidateId { get; }
        public GetExperiencesByCandidateIdQuery(int candidateId)
        {
            CandidateId = candidateId;
        }
    }

    public class GetExperiencesByCandidateIdQueryHandler : IRequestHandler<GetExperiencesByCandidateIdQuery, IEnumerable<ExperienceDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetExperiencesByCandidateIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceDTO>> Handle(GetExperiencesByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var experiences = await Task.FromResult(_repository.Experiences.GetExperienceByCandidadeId(request.CandidateId));

            if (experiences.Count() <= 0)
            {
                throw new EntityNotFoundException($"No experience found for Id {request.CandidateId}");
            }

            return _mapper.Map<IEnumerable<ExperienceDTO>>(experiences);
        }
    }
}
