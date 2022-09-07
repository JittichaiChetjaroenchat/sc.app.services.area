using System;
using System.Collections.Generic;
using SC.App.Services.Area.Common.Repositories;

namespace SC.App.Services.Area.Business.Repositories.Interface
{
    public interface IRegionRepository : IRepository
    {
        Database.Models.Region GetById(Guid id);

        List<Database.Models.Region> GetAll();
    }
}