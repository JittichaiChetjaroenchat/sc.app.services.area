using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Queries.Region;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Handlers.Region
{
    public class GetRegionByFilterHandler : BaseHandler, IRequestHandler<GetRegionByFilterQuery, Response<List<GetRegionResponse>>>
    {
        private readonly IConfiguration _configuration;
        private readonly IRegionManager _regionManager;

        public GetRegionByFilterHandler(
            IConfiguration configuration,
            IRegionManager areaManager) : base(configuration)
        {
            _configuration = configuration;
            _regionManager = areaManager;
        }

        public async Task<Response<List<GetRegionResponse>>> Handle(GetRegionByFilterQuery query, CancellationToken cancellationToken)
        {
            return await _regionManager.GetAsync(_configuration, query);
        }
    }
}