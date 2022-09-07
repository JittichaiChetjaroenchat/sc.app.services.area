using System.Collections.Generic;
using System.Linq;
using SC.App.Services.Area.Business.Queries.Region;

namespace SC.App.Services.Area.Business.Mappers
{
    public class RegionMapper
    {
        public static List<GetRegionResponse> Map(List<Database.Models.Region> regions)
        {
            return regions.Select(Map)
                .ToList();
        }

        public static GetRegionResponse Map(Database.Models.Region region)
        {
            return new GetRegionResponse
            {
                Id = region.Id,
                Code = region.Code,
                Description = region.Description
            };
        }
    }
}