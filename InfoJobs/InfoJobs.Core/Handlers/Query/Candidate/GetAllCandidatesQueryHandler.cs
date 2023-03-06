using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfoJobs.Query
{
    public class GetAllCandidatesQuery : IRequest<IEnumerable<CandidateDTO>>
    {
    }

    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllCandidatesQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateDTO>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Candidates.GetAll().Include(x => x.Experiences).ToList());
            return _mapper.Map<IEnumerable<CandidateDTO>>(entities);
        }
    }
}
