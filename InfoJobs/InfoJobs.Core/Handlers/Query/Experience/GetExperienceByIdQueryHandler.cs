using AutoMapper;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Query
{
    public class GetExperienceByIdQuery : IRequest<ExperienceDTO>
    {
        public int ExperienceId { get; }
        public GetExperienceByIdQuery(int experienceId)
        {
            ExperienceId = experienceId;
        }
    }

    public class GetExperienceByIdQueryHandler : IRequestHandler<GetExperienceByIdQuery, ExperienceDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetExperienceByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ExperienceDTO> Handle(GetExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            var experience = await Task.FromResult(_repository.Experiences.Get(request.ExperienceId));

            if (experience == null)
            {
                throw new EntityNotFoundException($"No experience found for Id {request.ExperienceId}");
            }

            return _mapper.Map<ExperienceDTO>(experience);
        }
    }
}
