using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Services.Area.Database.Models;
using SC.App.Services.Area.Lib.Helpers;

namespace SC.App.Services.Area.Database.Configurations
{
    public class RegionConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable(Constants.Region.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
            builder.HasData(
                new Region { Id = GuidHelper.Generate(Data.Region.North.Code), Code = Data.Region.North.Code, Description = Data.Region.North.Description, Index = 1 },
                new Region { Id = GuidHelper.Generate(Data.Region.NorthEast.Code), Code = Data.Region.NorthEast.Code, Description = Data.Region.NorthEast.Description, Index = 2 },
                new Region { Id = GuidHelper.Generate(Data.Region.West.Code), Code = Data.Region.West.Code, Description = Data.Region.West.Description, Index = 3 },
                new Region { Id = GuidHelper.Generate(Data.Region.Central.Code), Code = Data.Region.Central.Code, Description = Data.Region.Central.Description, Index = 4 },
                new Region { Id = GuidHelper.Generate(Data.Region.East.Code), Code = Data.Region.East.Code, Description = Data.Region.East.Description, Index = 5 },
                new Region { Id = GuidHelper.Generate(Data.Region.South.Code), Code = Data.Region.South.Code, Description = Data.Region.South.Description, Index = 6 }
            );
        }
    }
}