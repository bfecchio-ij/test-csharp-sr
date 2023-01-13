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
    public class CandidateGetAllQueryHandler : IRequestHandler<CandidateGetAllQuery, IEnumerable<Candidates>>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Candidates> _candidatesRepository;

        public CandidateGetAllQueryHandler(IMediator mediator, IRepository<Candidates> candidatesRepository)
        {
            _mediator = mediator;
            _candidatesRepository = candidatesRepository;
        }

        public async Task<IEnumerable<Candidates>> Handle(CandidateGetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var lst = await _candidatesRepository.GetAll();

                return await Task.FromResult(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
