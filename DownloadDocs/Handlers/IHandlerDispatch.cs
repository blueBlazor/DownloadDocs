
using DownloadDocs.Helpers;

namespace DownloadDocs.Handlers
{
    public interface IRequestHandler<TRequest, TResponse>
      where TRequest : class
    {
        //Task<Response<TResponse>> HandleAsync(Request<TRequest> request, CancellationToken ct = default);
        Task<Response<byte[]>> HandleAsync(Request<TRequest> request, CancellationToken ct = default);
    }
    public interface IHandlerDispatch
    {

        Task<Response<byte[]>> DispatchAsyncByte<TRequest>(Request<TRequest> request, CancellationToken ct = default)
            where TRequest : class;
    }
}
