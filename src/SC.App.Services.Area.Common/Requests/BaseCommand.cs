using Microsoft.AspNetCore.Http;

namespace SC.App.Services.Area.Common.Requests
{
    public class BaseCommand
    {
        public HttpRequest Request { get; private set; }

        public BaseCommand(HttpRequest request)
        {
            Request = request;
        }
    }
}