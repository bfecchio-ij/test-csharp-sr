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
    public class CandidateDeleteHandler :  IRequestHandler<CandidateDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;
        private readonly IRepository<CandidateExperiences> _experiencesRepository;

        public CandidateDeleteHandler(IMediator mediator, IRepository<Candidates> candidatesRepository, IRepository<CandidateExperiences> experiencesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candidatesRepository;
            _experiencesRepository = experiencesRepository;
        }

        public async Task<string> Handle(CandidateDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Candidates candidate = _candidatesRepository.Select(request.IdCandidate).Result;

                if (candidate != null)
                {
                    await _candidatesRepository.Delete(candidate.IdCandidates);

                    var experiences = from item in _experiencesRepository.GetAll().Result
                                      where item.IdCandidate == request.IdCandidate
                                      select item;

                    foreach(var experience in experiences)
                    {
                        await _experiencesRepository.Delete(experience.IdCandidateExperiences);
                    }

                    return await Task.FromResult("Candidate successfuly deleted");
                }
                else
                    return await Task.FromResult("Candidate not found");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }

        }
    }
}
