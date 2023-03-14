using LinkedinTest.Domain.Commands.Request;
using LinkedinTest.Domain.Commands.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedinTest.Domain.Commands.Handlers
{
    public interface ICreateCandidateHandler : IRequestHandler<CreateCandidateRequest, string>
    {
        Task<Guid> Handle(CreateCandidateRequest request, CancellationToken cancellationToken);
    }
}
