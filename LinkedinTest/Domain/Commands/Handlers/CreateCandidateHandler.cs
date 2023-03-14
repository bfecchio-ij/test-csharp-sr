using LinkedinTest.Data;
using LinkedinTest.Domain.Commands.Request;
using LinkedinTest.Domain.Commands.Responses;
using LinkedinTest.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedinTest.Domain.Commands.Handlers
{
    public class CreateCandidateHandler : ICreateCandidateHandler
    {
        private readonly IMediator _mediator;
        private readonly GenericRepository<CandidateModel> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCandidateHandler(IMediator mediator, GenericRepository<CandidateModel> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public Task<Guid> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = new CandidateModel() { Name= request.Name, Email = request.Email, Birthdate = request.Birthdate };
            _unitOfWork.CandidateRepo().context.Add(candidate);
            return Task.FromResult(candidate.Id);
        }

        Task<string> IRequestHandler<CreateCandidateRequest, string>.Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
