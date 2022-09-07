using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Queries.Region;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Managers.Interface
{
    public interface IRegionManager
    {
        Task<Response<GetRegionResponse>> GetAsync(IConfiguration configuration, GetRegionByIdQuery query);

        Task<Response<List<GetRegionResponse>>> GetAsync(IConfiguration configuration, GetRegionByFilterQuery query);
    }
}