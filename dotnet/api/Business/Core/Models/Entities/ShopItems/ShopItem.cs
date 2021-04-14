using System.Xml.Linq;
using AndcultureCode.CSharp.Core.Models;
using Rws.Api.Business.Core.Enumerations;

namespace Rws.Api.Core.Models.Entities
{
    public class ShopItem : Auditable
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public ShopItemType ItemType { get; set; }

        #endregion Properties
    }
}