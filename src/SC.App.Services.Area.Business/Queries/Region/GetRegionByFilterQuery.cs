using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.App.Services.Area.Common.Requests;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Queries.Region
{
    public class GetRegionByFilter
    {
    }

    public class GetRegionByFilterQuery : BaseQuery, IRequest<Response<List<GetRegionResponse>>>
    {
        public GetRegionByFilter Payload { get; private set; }

        public GetRegionByFilterQuery(HttpRequest request, GetRegionByFilter payload)
            : base(request)
        {
            Payload = payload;
        }
    }
}