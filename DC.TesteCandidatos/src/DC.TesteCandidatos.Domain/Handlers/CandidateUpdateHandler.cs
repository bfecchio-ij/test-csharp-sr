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
    public class CandidateUpdateHandler : IRequestHandler<CandidateUpdateCommand, String>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;

        public CandidateUpdateHandler(IMediator mediator, IRepository<Candidates> candidatesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candidatesRepository;
        }

        public async Task<string> Handle(CandidateUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Candidates candidate = _candidatesRepository.Select(request.Id).Result;

                if (candidate != null)
                {
                    candidate.Name = request.Name;
                    candidate.Surname = request.Surname;
                    candidate.Birthdate = request.Birthdate;
                    candidate.Email = request.Email;
                    candidate.ModifyDate = DateTime.Now;

                    await _candidatesRepository.Update(candidate);

                    return await Task.FromResult("Candidate successfuly updated");
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
