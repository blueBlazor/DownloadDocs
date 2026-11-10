using DownloadDocs.Helpers;

namespace DownloadDocs.Handlers
{
    public sealed class HandlerDispatch : IHandlerDispatch
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerDispatch(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }



        public async Task<Response<byte[]>> DispatchAsyncByte<TRequest>(Request<TRequest> request, CancellationToken ct = default) where TRequest : class
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, byte[]>>();

            return await handler.HandleAsync(request, ct);
        }
    }

}
