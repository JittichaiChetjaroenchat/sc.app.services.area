using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Services.Area.Business.Repositories.Interface;
using SC.App.Services.Area.Database;

namespace SC.App.Services.Area.Business.Repositories
{
    public class RegionRepository : BaseRepository, IRegionRepository
    {
        public RegionRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public Database.Models.Region GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Regions
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Database.Models.Region> GetAll()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Regions
                    .OrderBy(x => x.Index)
                    .ToList();
            }
        }
    }
}