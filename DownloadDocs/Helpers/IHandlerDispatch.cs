namespace DownloadDocs.Helpers
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : class
    {
        Task<Response<TResponse>> HandleAsync(Request<TRequest> request, CancellationToken ct = default);
    }
    public interface IHandlerDispatch
    {
        Task<Response<TResponse>> DispatchAsync<TRequest, TResponse>(Request<TRequest> request, CancellationToken ct = default) where TRequest : class;
    }
}
