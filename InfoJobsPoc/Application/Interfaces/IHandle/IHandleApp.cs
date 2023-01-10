namespace InfoJobsPoc.Application.Interfaces.IHandle
{
    public interface IHandleApp<TReq, TRes> where TReq : class
    {
        Task<TRes> Handle(TReq request, CancellationToken cancellationToken);
    }

}
