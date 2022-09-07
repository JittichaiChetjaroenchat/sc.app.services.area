using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SC.App.Services.Area.Common.Requests;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Queries.Region
{
    public class GetRegionById
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        public GetRegionById(Guid id)
        {
            Id = id;
        }
    }

    public class GetRegionByIdQuery : BaseQuery, IRequest<Response<GetRegionResponse>>
    {
        public GetRegionById Payload { get; private set; }

        public GetRegionByIdQuery(HttpRequest request, GetRegionById payload)
            : base(request)
        {
            Payload = payload;
        }
    }
}