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
    public class ExperiencesGetAllHandler : IRequestHandler<ExperiencesGetAllQuery, IEnumerable<CandidateExperiences>>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public ExperiencesGetAllHandler(IMediator mediator, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<IEnumerable<CandidateExperiences>> Handle(ExperiencesGetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_experiencesRepository.GetAll().Result.ToList());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
