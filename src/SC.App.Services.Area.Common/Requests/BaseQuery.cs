using Microsoft.AspNetCore.Http;

namespace SC.App.Services.Area.Common.Requests
{
    public class BaseQuery
    {
        public HttpRequest Request { get; private set; }

        public BaseQuery(HttpRequest request)
        {
            Request = request;
        }
    }
}