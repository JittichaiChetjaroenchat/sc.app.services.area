using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Queries.Area;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Business.Managers.Interface
{
    public interface IAreaManager
    {
        Task<Response<GetAreaResponse>> GetAsync(IConfiguration configuration, GetAreaByIdQuery query);

        Task<Response<List<GetAreaResponse>>> GetAsync(IConfiguration configuration, GetAreaByFilterQuery query);
    }
}