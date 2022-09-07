using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Constants;
using SC.App.Services.Area.Business.Enums;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Mappers;
using SC.App.Services.Area.Business.Queries.Region;
using SC.App.Services.Area.Business.Repositories.Interface;
using SC.App.Services.Area.Business.Resources;
using SC.App.Services.Area.Common.Constants;
using SC.App.Services.Area.Common.Helpers;
using SC.App.Services.Area.Common.Managers;
using SC.App.Services.Area.Common.Managers.Cache;
using SC.App.Services.Area.Common.Responses;
using SC.App.Services.Area.Lib.Extensions;
using Serilog;

namespace SC.App.Services.Area.Business.Managers
{
    public class RegionManager : BaseManager<IRegionRepository>, IRegionManager
    {
        private readonly IDistributedCacheManager _cacheManager;

        public RegionManager(
            IRegionRepository repository,
            IDistributedCacheManager cacheManager)
            : base(repository)
        {
            _cacheManager = cacheManager;
        }

        public async Task<Response<GetRegionResponse>> GetAsync(IConfiguration configuration, GetRegionByIdQuery query)
        {
            GetRegionResponse data = null;
            List<ResponseError> errors = new List<ResponseError>();
            Response<GetRegionResponse> response = null;

            try
            {
                // Get area
                var area = Repository.GetById(query.Payload.Id);
                if (area == null)
                {
                    errors.Add(new ResponseError { Code = EnumErrorCode._101040002.GetDescription(), Message = ErrorMessage._101040002 });
                    response = ResponseHelper.Error<GetRegionResponse>(errors);

                    return await Task.FromResult(response);
                }

                // Build response
                data = RegionMapper.Map(area);
                response = ResponseHelper.Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);

                errors.Add(new ResponseError { Code = null, Message = ex.Message });
                response = ResponseHelper.Error<GetRegionResponse>(errors);
            }

            return await Task.FromResult(response);
        }

        public async Task<Response<List<GetRegionResponse>>> GetAsync(IConfiguration configuration, GetRegionByFilterQuery query)
        {
            List<GetRegionResponse> data = null;
            List<ResponseError> errors = new List<ResponseError>();
            Response<List<GetRegionResponse>> response = null;

            try
            {
                var regions = _cacheManager.Get<List<Database.Models.Region>>(CacheKey.Regions);
                if (regions == null)
                {
                    // Get regions
                    regions = Repository.GetAll();

                    // Cache
                    var cacheTime = configuration.GetValue<int>(AppSettings.Cache.CacheTime);
                    _cacheManager.Set(CacheKey.Regions, regions, cacheTime);
                }

                // Build response
                data = RegionMapper.Map(regions);
                response = ResponseHelper.Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);

                errors.Add(new ResponseError { Code = null, Message = ex.Message });
                response = ResponseHelper.Error<List<GetRegionResponse>>(errors);
            }

            return await Task.FromResult(response);
        }
    }
}