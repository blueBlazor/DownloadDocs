

namespace DownloadDocs.Helpers
{

    public sealed record Result<T>(bool IsSuccess, T? data, string Title, string message) where T : class
    {
        public static Result<T> Success(T data, string title, string message) => new(true, data, title, message);
        public static Result<T> Failure(string Title, string Message) => new(false, null, Title, Message);
    }

}
