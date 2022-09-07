using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Services.Area.Business.Repositories.Interface;
using SC.App.Services.Area.Database;

namespace SC.App.Services.Area.Business.Repositories
{
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        public AreaRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public Database.Models.Area GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Areas
                    .Include(x => x.Region)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Database.Models.Area> GetAll()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Areas
                    .Include(x => x.Region)
                    .OrderBy(x => x.Province)
                    .ThenBy(x => x.District)
                    .ThenBy(x => x.SubDistrict)
                    .ThenBy(x => x.PostalCode)
                    .ToList();
            }
        }

        public int Count()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Areas
                    .Count();
            }            
        }
    }
}