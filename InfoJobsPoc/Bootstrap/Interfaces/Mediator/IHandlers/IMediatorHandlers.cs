using MediatR;

namespace InfoJobsPoc.Bootstrap.Interfaces.Mediator.IHandlers
{
    public interface IMediatorHandlers<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

    }
}
