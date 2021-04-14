using Microsoft.AspNetCore.Mvc;

namespace Rws.Api.Presentation.Web.Controllers.ShopItem
{
    [Route("api/shopitem")]
    public class ShopItemController : Controller
    {
        [HttpGet]
        public ActionResult<bool> Index()
        {
            return Ok("Welp");
        }
    }
}