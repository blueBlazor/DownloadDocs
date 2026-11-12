namespace DownloadDocs.Helpers
{
    public sealed class HandlerDispatch : IHandlerDispatch
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerDispatch(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Response<TResponse>> DispatchAsync<TRequest, TResponse>(Request<TRequest> request, CancellationToken ct = default)
            where TRequest : class
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            return await handler.HandleAsync(request, ct);
        }
    }

}
