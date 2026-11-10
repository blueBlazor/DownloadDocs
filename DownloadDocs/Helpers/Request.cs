namespace DownloadDocs.Helpers
{
    public sealed record Request<T>(T Data) where T : class;

}

