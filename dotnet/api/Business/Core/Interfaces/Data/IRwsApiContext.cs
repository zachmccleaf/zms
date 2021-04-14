using Rws.Api.Core.Models.Entities;
using System.Linq;

namespace Rws.Api.Business.Core.Interfaces.Data
{
    public interface IRwsApiContext
    {
        IQueryable<ShopItem> ShopItems { get; }
    }
}
