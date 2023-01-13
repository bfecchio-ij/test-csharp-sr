using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Interfaces;
using DC.TesteCandidatos.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Handlers
{
    public class ExperiencesSelectHandler : IRequestHandler<ExperiencesSelectQuery, CandidateExperiences>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public ExperiencesSelectHandler(IMediator mediator, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<CandidateExperiences> Handle(ExperiencesSelectQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _experiencesRepository.Select(request.IdExperience).Result;

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
