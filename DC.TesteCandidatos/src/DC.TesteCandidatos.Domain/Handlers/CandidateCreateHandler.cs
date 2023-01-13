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
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;

        public CandidateCreateHandler(IMediator mediator, IRepository<Candidates> candidatesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candidatesRepository;
        }

        public async Task<String> Handle(CandidateCreateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidates
            {
                Name = request.Name,
                Surname = request.Surname,
                Birthdate = request.Birthdate,
                Email = request.Email,
                InsertDate = DateTime.Now
            };

            try
            {
                var response = await _candidatesRepository.Add(candidate);

                return await Task.FromResult("Candidate successfully include");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }

    }
}
