using MediatR;

namespace InfoJobsPoc.Bootstrap.Interfaces.Mediator.IMediatorRequest
{
    public interface IMediatorRequest<out T> : IRequest<T> where T : class
    {
    }
}
