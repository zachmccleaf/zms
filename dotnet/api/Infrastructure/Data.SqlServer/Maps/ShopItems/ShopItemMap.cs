using AndcultureCode.CSharp.Core.Models.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rws.Api.Core.Models.Entities;
using Rws.Api.Infrastructure.Data.SqlServer.Maps;

namespace Data.SqlServer.Maps.ShopItems
{
    public class ShopItemMap : Map<ShopItem>
    {
        public override void Configure(EntityTypeBuilder<ShopItem> entity)
        {
            entity.Property(e => e.Description)
                .HasMaxLength(DataConfiguration.SHORT_STRING_LENGTH);

            entity.Property(e => e.Name)
                .HasMaxLength(DataConfiguration.SHORT_STRING_LENGTH);
        }
    }
}