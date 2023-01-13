using DC.TesteCandidatos.Domain.Commands;
using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Handlers
{
    public class ExperiencesDeleteHandler : IRequestHandler<ExperienceDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public ExperiencesDeleteHandler(IMediator mediator, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<string> Handle(ExperienceDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _experiencesRepository.Delete(request.IdExperience);

                return await Task.FromResult("Experience succesfuly deleted");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
