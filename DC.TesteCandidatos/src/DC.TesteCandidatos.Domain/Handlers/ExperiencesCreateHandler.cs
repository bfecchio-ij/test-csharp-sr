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
    public class ExperiencesCreateHandler : IRequestHandler<ExperienceCreateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public ExperiencesCreateHandler(IMediator mediator, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<string> Handle(ExperienceCreateCommand request, CancellationToken cancellationToken)
        {
            var experience = new CandidateExperiences();
            experience.IdCandidate = request.IdCandidatos;
            experience.Company = request.Company;
            experience.Job = request.Job;
            experience.Salary = request.Salary;
            experience.Description = request.Description;
            experience.BeginDate = request.BeginDate;
            experience.EndDate = request.EndDate;
            experience.InsertDate = DateTime.Now;

            try
            {
                var response = _experiencesRepository.Add(experience).Result;

                return await Task.FromResult("Experience successfuly include");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
