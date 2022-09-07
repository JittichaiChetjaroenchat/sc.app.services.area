using System;
using System.Collections.Generic;
using SC.App.Services.Area.Common.Repositories;

namespace SC.App.Services.Area.Business.Repositories.Interface
{
    public interface IAreaRepository : IRepository
    {
        Database.Models.Area GetById(Guid id);

        List<Database.Models.Area> GetAll();

        int Count();
    }
}