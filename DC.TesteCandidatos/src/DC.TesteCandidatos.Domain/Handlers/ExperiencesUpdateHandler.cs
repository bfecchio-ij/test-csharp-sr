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
    public class ExperiencesUpdateHandler : IRequestHandler<ExperienceUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public ExperiencesUpdateHandler(IMediator mediator, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<string> Handle(ExperienceUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CandidateExperiences experiences = _experiencesRepository.Select(request.IdExperience).Result;

                if(experiences != null)
                {
                    experiences.Company = request.Company;
                    experiences.Job = request.Job;
                    experiences.Salary = request.Salary;
                    experiences.Description = request.Description;
                    experiences.BeginDate = request.BeginDate;
                    experiences.EndDate = request.EndDate;
                    experiences.ModifyDate = DateTime.Now;

                    await _experiencesRepository.Update(experiences);

                    return await Task.FromResult("Experience succesfully updated");
                }
                else
                {
                    return await Task.FromResult("Experience not found");
                }
            }
            catch(Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
