using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SC.App.Services.Area.Common.Requests;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Queries.Area
{
    public class GetAreaById
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        public GetAreaById(Guid id)
        {
            Id = id;
        }
    }

    public class GetAreaByIdQuery : BaseQuery, IRequest<Response<GetAreaResponse>>
    {
        public GetAreaById Payload { get; private set; }

        public GetAreaByIdQuery(HttpRequest request, GetAreaById payload)
            : base(request)
        {
            Payload = payload;
        }
    }
}