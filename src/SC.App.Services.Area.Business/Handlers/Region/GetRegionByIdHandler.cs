using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Queries.Region;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Handlers.Region
{
    public class GetRegionByIdHandler : BaseHandler, IRequestHandler<GetRegionByIdQuery, Response<GetRegionResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly IRegionManager _regionManager;

        public GetRegionByIdHandler(
            IConfiguration configuration,
            IRegionManager regionManager) : base(configuration)
        {
            _configuration = configuration;
            _regionManager = regionManager;
        }

        public async Task<Response<GetRegionResponse>> Handle(GetRegionByIdQuery query, CancellationToken cancellationToken)
        {
            return await _regionManager.GetAsync(_configuration, query);
        }
    }
}