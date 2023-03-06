using AutoMapper;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Query
{

    public class GetAllExperiencesQuery : IRequest<IEnumerable<ExperienceDTO>>
    {
    }

    public class GetAllExperiencesQueryHandler : IRequestHandler<GetAllExperiencesQuery, IEnumerable<ExperienceDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllExperiencesQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceDTO>> Handle(GetAllExperiencesQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Experiences.GetAll());
            return _mapper.Map<IEnumerable<ExperienceDTO>>(entities);
        }
    }
}
