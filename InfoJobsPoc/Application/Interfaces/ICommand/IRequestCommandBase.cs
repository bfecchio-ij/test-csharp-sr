using InfoJobsPoc.Bootstrap.Interfaces.Mediator.IMediatorRequest;

namespace InfoJobsPoc.Application.Interfaces.ICommand
{
    public interface IRequestCommandBase<out T> : IMediatorRequest<T> where T : class
    {
    }
}

