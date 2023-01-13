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
    public class CandidateSelectQueryHandler : IRequestHandler<CandidateSelectQuery, Candidates>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;

        public CandidateSelectQueryHandler(IMediator mediator, IRepository<Candidates> candidatesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candidatesRepository;
        }

        public async Task<Candidates> Handle(CandidateSelectQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var candidate = _candidatesRepository.Select(request.Id).Result;
                return await Task.FromResult(candidate);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
