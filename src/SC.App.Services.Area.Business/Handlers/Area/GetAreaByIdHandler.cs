using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Queries.Area;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Handlers.Area
{
    public class GetAreaByIdHandler : BaseHandler, IRequestHandler<GetAreaByIdQuery, Response<GetAreaResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly IAreaManager _areaManager;

        public GetAreaByIdHandler(
            IConfiguration configuration,
            IAreaManager areaManager) : base(configuration)
        {
            _configuration = configuration;
            _areaManager = areaManager;
        }

        public async Task<Response<GetAreaResponse>> Handle(GetAreaByIdQuery query, CancellationToken cancellationToken)
        {
            return await _areaManager.GetAsync(_configuration, query);
        }
    }
}