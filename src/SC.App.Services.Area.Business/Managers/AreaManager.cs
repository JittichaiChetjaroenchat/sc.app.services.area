using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Services.Area.Business.Constants;
using SC.App.Services.Area.Business.Enums;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Mappers;
using SC.App.Services.Area.Business.Queries.Area;
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
    public class AreaManager : BaseManager<IAreaRepository>, IAreaManager
    {
        private readonly IDistributedCacheManager _cacheManager;

        public AreaManager(
            IAreaRepository repository,
            IDistributedCacheManager cacheManager)
            : base(repository)
        {
            _cacheManager = cacheManager;
        }

        public async Task<Response<GetAreaResponse>> GetAsync(IConfiguration configuration, GetAreaByIdQuery query)
        {
            GetAreaResponse data = null;
            List<ResponseError> errors = new List<ResponseError>();
            Response<GetAreaResponse> response = null;

            try
            {
                // Get area
                var area = Repository.GetById(query.Payload.Id);
                if (area == null)
                {
                    errors.Add(new ResponseError { Code = EnumErrorCode._101040001.GetDescription(), Message = ErrorMessage._101040001 });
                    response = ResponseHelper.Error<GetAreaResponse>(errors);

                    return await Task.FromResult(response);
                }

                // Build response
                data = AreaMapper.Map(area);
                response = ResponseHelper.Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);

                errors.Add(new ResponseError { Code = null, Message = ex.Message });
                response = ResponseHelper.Error<GetAreaResponse>(errors);
            }

            return await Task.FromResult(response);
        }

        public async Task<Response<List<GetAreaResponse>>> GetAsync(IConfiguration configuration, GetAreaByFilterQuery query)
        {
            List<GetAreaResponse> data = null;
            List<ResponseError> errors = new List<ResponseError>();
            Response<List<GetAreaResponse>> response = null;

            try
            {
                var numberOfArea = Repository.Count();
                var areas = _cacheManager.Get<List<Database.Models.Area>>(CacheKey.Areas);
                if (areas == null || areas.Count != numberOfArea)
                {
                    // Get areas
                    areas = Repository.GetAll();

                    // Cache
                    var cacheTime = configuration.GetValue<int>(AppSettings.Cache.CacheTime);
                    _cacheManager.Set(CacheKey.Areas, areas, cacheTime);
                }

                // Build response
                data = AreaMapper.Map(areas);
                response = ResponseHelper.Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);

                errors.Add(new ResponseError { Code = null, Message = ex.Message });
                response = ResponseHelper.Error<List<GetAreaResponse>>(errors);
            }

            return await Task.FromResult(response);
        }
    }
}