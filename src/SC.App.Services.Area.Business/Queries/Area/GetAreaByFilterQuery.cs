using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.App.Services.Area.Common.Requests;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Queries.Area
{
    public class GetAreaByFilter
    {
    }

    public class GetAreaByFilterQuery : BaseQuery, IRequest<Response<List<GetAreaResponse>>>
    {
        public GetAreaByFilter Payload { get; private set; }

        public GetAreaByFilterQuery(HttpRequest request, GetAreaByFilter payload)
            : base(request)
        {
            Payload = payload;
        }
    }
}