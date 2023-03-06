using AutoMapper;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Query
{
    public class GetCandidateByIdQuery : IRequest<CandidateDTO>
    {
        public int CandidateId { get; }

        public GetCandidateByIdQuery(int candidateId)
        {
            CandidateId = candidateId;
        }
    }

    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetCandidateByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CandidateDTO> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await Task.FromResult(_repository.Candidates.GetByIdInclude(request.CandidateId));

            if (candidate == null)
            {
                throw new EntityNotFoundException($"No candidate found for Id {request.CandidateId}");
            }

            return _mapper.Map<CandidateDTO>(candidate);
        }
    }
}

