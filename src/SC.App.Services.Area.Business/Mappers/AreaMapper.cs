using System.Collections.Generic;
using System.Linq;
using SC.App.Services.Area.Business.Queries.Area;

namespace SC.App.Services.Area.Business.Mappers
{
    public class AreaMapper
    {
        public static List<GetAreaResponse> Map(List<Database.Models.Area> areas)
        {
            return areas.Select(Map)
                .ToList();
        }

        public static GetAreaResponse Map(Database.Models.Area area)
        {
            return new GetAreaResponse
            {
                Id = area.Id,
                Region = GetRegion(area.Region),
                Province = area.Province,
                District = area.District,
                SubDistrict = area.SubDistrict,
                PostalCode = area.PostalCode,
                IsCapital = area.IsCapital,
                IsPerimeter = area.IsPerimeter,
                Label = GetLabel(area)
            };
        }

        private static string GetLabel(Database.Models.Area area)
        {
            return $"{area.SubDistrict} {area.District} {area.Province} {area.PostalCode}";
        }

        private static GetRegion GetRegion(Database.Models.Region region)
        {
            return new GetRegion
            {
                Code = region.Code
            };
        }
    }
}